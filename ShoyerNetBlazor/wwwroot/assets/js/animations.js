// Select the div you want to observe
const loadAboutUsDiv = document.getElementById("aboutUs-container");

function loadAboutUsRun() {
    lottie.loadAnimation({
        container: document.getElementById('aboutUs-container'),
        renderer: 'svg',
        loop: false,
        autoplay: true,
        path: '/assets/clips/aboutus.json' // Your Lottie JSON file
    });
}

// Function to execute when the div appears
function loadAboutUs() {
    loadAboutUsRun();
}

// Function to call when div appears
function onDivVisible(entries, observer) {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            console.log("Div is now visible!");
            loadAboutUsRun(); // Call your function here
            observer.unobserve(entry.target); // Stop observing if needed
        }
    });
}

// Create an Intersection Observer
const observer = new IntersectionObserver(onDivVisible, {
    root: null, // Observe relative to the viewport
    rootMargin: "0px",
    threshold: 0.9 // Trigger when 50% of the div is visible
});

// Start observing the target div
observer.observe(loadAboutUsDiv);

