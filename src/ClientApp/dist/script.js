document.addEventListener('DOMContentLoaded', function() {
    // Load content based on the hash in the URL
    function loadContent() {
        const hash = location.hash || '#home'; // Default to #home if no hash is present
        fetchContent(hash.substring(1)); // Remove the '#' character
    }

    // Fetch content from a specific page file
    function fetchContent(page) {
        fetch(`${page}.html`)
            .then(response => response.text())
            .then(data => {
                document.getElementById('content').innerHTML = data;
            })
            .catch(error => {
                console.error('Error loading content:', error);
                document.getElementById('content').innerHTML = '<p>Page not found.</p>';
            });
    }

    // Initial content load
    loadContent();

    // Listen for hash changes to load new content
    window.addEventListener('hashchange', loadContent);
});
