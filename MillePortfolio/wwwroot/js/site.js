// ============================================
// MILLE PORTFOLIO - Enhanced JavaScript
// ============================================

(function () {
    'use strict';

    // ============================================
    // UTILITY FUNCTIONS
    // ============================================

    // Throttle function - limits how often a function can fire
    function throttle(func, limit) {
        let inThrottle;
        return function (...args) {
            if (!inThrottle) {
                func.apply(this, args);
                inThrottle = true;
                setTimeout(() => inThrottle = false, limit);
            }
        };
    }

    // Debounce function - waits until action stops
    function debounce(func, wait) {
        let timeout;
        return function (...args) {
            clearTimeout(timeout);
            timeout = setTimeout(() => func.apply(this, args), wait);
        };
    }

    // ============================================
    // NAVBAR SCROLL HANDLER (Throttled)
    // ============================================

    function initNavbarScroll() {
        const navbar = document.querySelector('.navbar');
        if (!navbar) return;

        const handleScroll = throttle(function () {
            const isScrolled = window.scrollY > 50;
            navbar.classList.toggle('scrolled', isScrolled);
        }, 100);

        window.addEventListener('scroll', handleScroll, { passive: true });
        // Initial check
        handleScroll();
    }

    // ============================================
    // DARK MODE WITH PERSISTENCE (Light mode default)
    // ============================================

    function initDarkMode() {
        const themeSwitch = document.getElementById('themeSwitch');
        const moonIcon = document.getElementById('moonIcon');
        const sunIcon = document.getElementById('sunIcon');
        const sliderIcons = document.querySelector('.slider-icons');

        if (!themeSwitch) return;

        // Check for saved preference - default to light mode
        function getPreferredTheme() {
            const savedTheme = localStorage.getItem('theme');
            // Only use dark mode if explicitly saved as 'dark'
            return savedTheme === 'dark' ? 'dark' : 'light';
        }

        function setTheme(theme) {
            const isDark = theme === 'dark';

            document.body.classList.toggle('dark-mode', isDark);
            themeSwitch.checked = isDark;

            if (moonIcon && sunIcon && sliderIcons) {
                moonIcon.style.display = isDark ? 'none' : 'block';
                sunIcon.style.display = isDark ? 'block' : 'none';
                sliderIcons.style.transform = isDark ? 'translateX(20px)' : 'translateX(0)';
            }

            localStorage.setItem('theme', theme);
        }

        // Apply saved preference on load (defaults to light)
        setTheme(getPreferredTheme());

        // Listen for toggle changes
        themeSwitch.addEventListener('change', function () {
            setTheme(this.checked ? 'dark' : 'light');
        });
    }

    // ============================================
    // SCROLL ANIMATIONS (Intersection Observer)
    // ============================================

    function initScrollAnimations() {
        const observerOptions = {
            threshold: 0.1,
            rootMargin: '0px 0px -50px 0px'
        };

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    entry.target.classList.add('animate-in');
                    // Don't unobserve - allows re-animation if desired
                }
            });
        }, observerOptions);

        // Observe all animatable elements
        document.querySelectorAll('.animate-on-scroll').forEach(el => {
            observer.observe(el);
        });

        // Auto-add animation class to sections
        document.querySelectorAll('section > div, .card, .about-me-card, .knowledge-card, .project-container, .impact-metric').forEach(el => {
            if (!el.classList.contains('animate-on-scroll')) {
                el.classList.add('animate-on-scroll');
                observer.observe(el);
            }
        });
    }

    // ============================================
    // ANIMATED COUNTERS
    // ============================================

    function initAnimatedCounters() {
        const counters = document.querySelectorAll('.impact-number');
        if (!counters.length) return;

        const observerOptions = {
            threshold: 0.5
        };

        const animateCounter = (element) => {
            const target = element.textContent.trim();
            const isPercentage = target.includes('%');
            const hasPlus = target.includes('+');
            const hasK = target.toLowerCase().includes('k');

            // Extract numeric value (handles 800k, 100%, 6+, etc.)
            const numericValue = parseInt(target.replace(/[^0-9]/g, ''));

            if (isNaN(numericValue)) return;

            // For 0, just display it without animation
            if (numericValue === 0) {
                element.textContent = '0';
                return;
            }

            let current = 0;
            const increment = numericValue / 50;
            const duration = 1500;
            const stepTime = duration / 50;

            // Build suffix string
            const suffix = (hasK ? 'k' : '') + (isPercentage ? '%' : '') + (hasPlus ? '+' : '');

            element.textContent = '0' + suffix;

            const timer = setInterval(() => {
                current += increment;
                if (current >= numericValue) {
                    current = numericValue;
                    clearInterval(timer);
                }
                element.textContent = Math.floor(current) + suffix;
            }, stepTime);
        };

        const observer = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting && !entry.target.dataset.animated) {
                    entry.target.dataset.animated = 'true';
                    animateCounter(entry.target);
                }
            });
        }, observerOptions);

        counters.forEach(counter => observer.observe(counter));
    }

    // ============================================
    // TYPING ANIMATION FOR HERO
    // ============================================

    function initTypingAnimation() {
        const heroText = document.querySelector('.hero-text');
        if (!heroText) return;

        const text = heroText.textContent;
        heroText.textContent = '';
        heroText.style.borderRight = '3px solid #b1f078';

        let charIndex = 0;
        const typeSpeed = 100;

        function type() {
            if (charIndex < text.length) {
                heroText.textContent += text.charAt(charIndex);
                charIndex++;
                setTimeout(type, typeSpeed);
            } else {
                // Remove cursor after typing completes
                setTimeout(() => {
                    heroText.style.borderRight = 'none';
                }, 1000);
            }
        }

        // Start typing after a short delay
        setTimeout(type, 500);
    }

    // ============================================
    // SMOOTH SCROLL FOR ANCHOR LINKS
    // ============================================

    function initSmoothScroll() {
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function (e) {
                const targetId = this.getAttribute('href');
                if (targetId === '#') return;

                const target = document.querySelector(targetId);
                if (target) {
                    e.preventDefault();
                    const navbarHeight = document.querySelector('.navbar')?.offsetHeight || 0;
                    const targetPosition = target.getBoundingClientRect().top + window.pageYOffset - navbarHeight - 20;

                    window.scrollTo({
                        top: targetPosition,
                        behavior: 'smooth'
                    });

                    // Highlight contact section when navigating to it
                    if (targetId === '#contact') {
                        setTimeout(() => {
                            highlightContactSection();
                        }, 500); // Wait for scroll to complete
                    }
                }
            });
        });
    }

    // ============================================
    // CONTACT SECTION HIGHLIGHT
    // ============================================

    function highlightContactSection() {
        const contactForm = document.querySelector('.contact-form-start');
        if (!contactForm) return;

        // Add highlight class
        contactForm.classList.add('highlight-pulse');

        // Remove after animation completes
        setTimeout(() => {
            contactForm.classList.remove('highlight-pulse');
        }, 2000);

        // Focus on first input for better UX
        const firstInput = contactForm.querySelector('input');
        if (firstInput) {
            setTimeout(() => firstInput.focus(), 600);
        }
    }

    // ============================================
    // PROJECT CARD TEXT TOGGLE (Improved)
    // ============================================

    window.toggleText = function (button) {
        const text = button.previousElementSibling;
        if (!text) return;

        const isCollapsed = text.classList.contains('text-collapsed');
        text.classList.toggle('text-collapsed');

        // Smooth transition
        if (isCollapsed) {
            button.innerHTML = '<i class="fa-solid fa-arrow-up"></i>';
            button.setAttribute('aria-expanded', 'true');
        } else {
            button.innerHTML = '<i class="fa-solid fa-arrow-down"></i>';
            button.setAttribute('aria-expanded', 'false');
        }
    };

    // ============================================
    // PARALLAX EFFECT FOR HERO
    // ============================================

    function initParallax() {
        const hero = document.querySelector('.hero-image');
        if (!hero) return;

        const handleParallax = throttle(function () {
            const scrolled = window.pageYOffset;
            const rate = scrolled * 0.3;
            hero.style.transform = `translateY(${rate}px)`;
        }, 16);

        window.addEventListener('scroll', handleParallax, { passive: true });
    }

    // ============================================
    // NAVBAR ACTIVE LINK HIGHLIGHT
    // ============================================

    function initActiveNavHighlight() {
        const sections = document.querySelectorAll('section[id]');
        const navLinks = document.querySelectorAll('.navbar-nav a[href^="#"]');

        if (!sections.length || !navLinks.length) return;

        const highlightNav = throttle(function () {
            const scrollPosition = window.scrollY + 100;

            sections.forEach(section => {
                const sectionTop = section.offsetTop;
                const sectionHeight = section.offsetHeight;
                const sectionId = section.getAttribute('id');

                if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
                    navLinks.forEach(link => {
                        link.classList.remove('active');
                        if (link.getAttribute('href') === `#${sectionId}`) {
                            link.classList.add('active');
                        }
                    });
                }
            });
        }, 100);

        window.addEventListener('scroll', highlightNav, { passive: true });
    }

    // ============================================
    // LAZY LOAD IMAGES
    // ============================================

    function initLazyLoad() {
        // Modern browsers support native lazy loading
        // This adds support for older browsers
        if ('loading' in HTMLImageElement.prototype) {
            // Native lazy loading supported
            document.querySelectorAll('img[data-src]').forEach(img => {
                img.src = img.dataset.src;
            });
        } else {
            // Fallback with Intersection Observer
            const imageObserver = new IntersectionObserver((entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting) {
                        const img = entry.target;
                        if (img.dataset.src) {
                            img.src = img.dataset.src;
                            img.removeAttribute('data-src');
                        }
                        imageObserver.unobserve(img);
                    }
                });
            });

            document.querySelectorAll('img[data-src]').forEach(img => {
                imageObserver.observe(img);
            });
        }
    }

    // ============================================
    // INITIALIZE EVERYTHING
    // ============================================

    function init() {
        initDarkMode();
        initNavbarScroll();
        initSmoothScroll();
        initScrollAnimations();
        initAnimatedCounters();
        initTypingAnimation();
        initParallax();
        initActiveNavHighlight();
        initLazyLoad();
    }

    // Run on DOM ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }

})();
