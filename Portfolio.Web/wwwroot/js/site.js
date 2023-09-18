// Home page skill section animations
$(document).ready(function () {
    const circularProgress = $(".circular-progress");
    const progressValues = $(".progress-value");
    const skills = [0, 0, 0, 0];
    const speed = 50;
    const progressEndValues = [90, 70, 80, 70];

    function updateProgress() {
        for (let i = 0; i < circularProgress.length; i++) {
            if (skills[i] < progressEndValues[i]) {
                skills[i]++;
                progressValues.eq(i).text(skills[i] + "%");
                circularProgress.eq(i).css("background", "conic-gradient(#1797ff " + skills[i] * 3.6 + "deg, #ededed 0deg)");
            }
        }

        const allSkillsComplete = skills.every(function (skill, index) {
            return skill === progressEndValues[index];
        });
        if (allSkillsComplete) {
            clearInterval(progressInterval);
        }
    }

    const progressInterval = setInterval(updateProgress, speed);
});

// Home page title, position, and passion statement animations
$(window).ready(function () {
    $(".title-text").fadeOut(function () {
        $(this).append("<span class='blue-span'>Kaleb</span> Garrett").fadeIn("slow")
    });

    $(".fullstack-dev").fadeOut(function () {
        $(this).append("Full Stack <span class='blue-span'>Developer</span>").fadeIn("slow")
    });
    
    $(".passion-statement").fadeOut(function () {
        $(this).append("<span class='blue-span'>Passionate</span> about <span class='blue-span'>.NET</span>").fadeIn("slow")
    });
});

// Opens resume 
$(document).ready(function (){
    $(".resume-btn").click(function (){
        window.open("/docs/Garrett-Resume-2023.pdf") 
    });
});