/* ============================================
   MODERN UI JAVASCRIPT
   Interactions et Animations
   ============================================ */

(function() {
  'use strict';

  // Initialisation au chargement du DOM
  document.addEventListener('DOMContentLoaded', function() {
    initAnimations();
    initTooltips();
    initFormValidation();
    initTableInteractions();
    initSmoothScroll();
    initLoadingStates();
  });

  /* ============================================
     ANIMATIONS AU SCROLL
     ============================================ */
  function initAnimations() {
    const observerOptions = {
      threshold: 0.1,
      rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver(function(entries) {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('animate-fade-in');
          observer.unobserve(entry.target);
        }
      });
    }, observerOptions);

    // Observer les cartes et éléments animables
    document.querySelectorAll('.card, .stats-card, .table-modern').forEach(el => {
      observer.observe(el);
    });
  }

  /* ============================================
     TOOLTIPS BOOTSTRAP
     ============================================ */
  function initTooltips() {
    if (typeof bootstrap !== 'undefined') {
      const tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
      tooltipTriggerList.map(function(tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
      });
    }
  }

  /* ============================================
     VALIDATION DES FORMULAIRES
     ============================================ */
  function initFormValidation() {
    const forms = document.querySelectorAll('.needs-validation');
    
    Array.prototype.slice.call(forms).forEach(function(form) {
      form.addEventListener('submit', function(event) {
        if (!form.checkValidity()) {
          event.preventDefault();
          event.stopPropagation();
        }
        form.classList.add('was-validated');
      }, false);
    });
  }

  /* ============================================
     INTERACTIONS DES TABLES
     ============================================ */
  function initTableInteractions() {
    const tableRows = document.querySelectorAll('.table-modern tbody tr');
    
    tableRows.forEach(row => {
      row.addEventListener('mouseenter', function() {
        this.style.transition = 'all 0.3s ease';
      });
    });
  }

  /* ============================================
     SCROLL SMOOTH
     ============================================ */
  function initSmoothScroll() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
      anchor.addEventListener('click', function(e) {
        const href = this.getAttribute('href');
        if (href !== '#' && href.length > 1) {
          e.preventDefault();
          const target = document.querySelector(href);
          if (target) {
            target.scrollIntoView({
              behavior: 'smooth',
              block: 'start'
            });
          }
        }
      });
    });
  }

  /* ============================================
     ETATS DE CHARGEMENT
     ============================================ */
  function initLoadingStates() {
    // Ajouter l'état de chargement aux boutons de soumission
    const submitButtons = document.querySelectorAll('button[type="submit"], input[type="submit"]');
    
    submitButtons.forEach(button => {
      button.addEventListener('click', function() {
        if (this.form && this.form.checkValidity()) {
          this.classList.add('loading');
          this.disabled = true;
        }
      });
    });
  }

  /* ============================================
     CONFIRMATION DE SUPPRESSION
     ============================================ */
  function confirmDelete(message) {
    return confirm(message || 'Êtes-vous sûr de vouloir supprimer cet élément ?');
  }

  // Exposer la fonction globalement
  window.confirmDelete = confirmDelete;

  /* ============================================
     NOTIFICATIONS TOAST (si Bootstrap 5 disponible)
     ============================================ */
  function showToast(message, type = 'info') {
    if (typeof bootstrap === 'undefined') {
      alert(message);
      return;
    }

    const toastContainer = document.getElementById('toast-container') || createToastContainer();
    const toast = createToastElement(message, type);
    toastContainer.appendChild(toast);
    
    const bsToast = new bootstrap.Toast(toast);
    bsToast.show();
    
    toast.addEventListener('hidden.bs.toast', function() {
      toast.remove();
    });
  }

  function createToastContainer() {
    const container = document.createElement('div');
    container.id = 'toast-container';
    container.className = 'toast-container position-fixed top-0 end-0 p-3';
    container.style.zIndex = '9999';
    document.body.appendChild(container);
    return container;
  }

  function createToastElement(message, type) {
    const toast = document.createElement('div');
    toast.className = `toast align-items-center text-white bg-${type} border-0`;
    toast.setAttribute('role', 'alert');
    toast.setAttribute('aria-live', 'assertive');
    toast.setAttribute('aria-atomic', 'true');
    
    const icons = {
      success: 'check-circle-fill',
      danger: 'exclamation-triangle-fill',
      warning: 'exclamation-triangle-fill',
      info: 'info-circle-fill'
    };
    
    toast.innerHTML = `
      <div class="d-flex">
        <div class="toast-body">
          <i class="bi bi-${icons[type] || 'info-circle-fill'} me-2"></i>
          ${message}
        </div>
        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
      </div>
    `;
    
    return toast;
  }

  // Exposer la fonction globalement
  window.showToast = showToast;

  /* ============================================
     NAVBAR SCROLL EFFECT
     ============================================ */
  let lastScroll = 0;
  const navbar = document.querySelector('.site-header');
  
  if (navbar) {
    window.addEventListener('scroll', function() {
      const currentScroll = window.pageYOffset;
      
      if (currentScroll > 100) {
        navbar.style.boxShadow = '0 10px 30px rgba(0, 0, 0, 0.2)';
      } else {
        navbar.style.boxShadow = '0 4px 6px rgba(0, 0, 0, 0.1)';
      }
      
      lastScroll = currentScroll;
    });
  }

  /* ============================================
     AUTO-HIDE ALERTS
     ============================================ */
  const alerts = document.querySelectorAll('.alert:not(.alert-permanent)');
  alerts.forEach(alert => {
    setTimeout(() => {
      if (typeof bootstrap !== 'undefined') {
        const bsAlert = new bootstrap.Alert(alert);
        bsAlert.close();
      } else {
        alert.style.transition = 'opacity 0.5s';
        alert.style.opacity = '0';
        setTimeout(() => alert.remove(), 500);
      }
    }, 5000);
  });

  /* ============================================
     COPY TO CLIPBOARD
     ============================================ */
  function copyToClipboard(text) {
    if (navigator.clipboard) {
      navigator.clipboard.writeText(text).then(() => {
        showToast('Copié dans le presse-papiers !', 'success');
      });
    } else {
      // Fallback pour anciens navigateurs
      const textarea = document.createElement('textarea');
      textarea.value = text;
      document.body.appendChild(textarea);
      textarea.select();
      document.execCommand('copy');
      document.body.removeChild(textarea);
      showToast('Copié dans le presse-papiers !', 'success');
    }
  }

  window.copyToClipboard = copyToClipboard;

  /* ============================================
     FORMATAGE DES NOMBRES
     ============================================ */
  function formatCurrency(amount, currency = 'EUR') {
    return new Intl.NumberFormat('fr-FR', {
      style: 'currency',
      currency: currency
    }).format(amount);
  }

  function formatDate(date) {
    return new Intl.DateTimeFormat('fr-FR', {
      year: 'numeric',
      month: 'long',
      day: 'numeric'
    }).format(new Date(date));
  }

  window.formatCurrency = formatCurrency;
  window.formatDate = formatDate;

  console.log('✅ Modern UI JavaScript chargé avec succès');
})();

