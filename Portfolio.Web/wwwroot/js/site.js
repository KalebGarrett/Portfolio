$(document).ready(function () {
    // Iterate through each skill circle
    $(".skill-circle").each(function () {
        var skillValue = parseInt($(this).data("value")); // Get the skill value from data attribute
        var skillColor = calculateSkillColor(skillValue); // Calculate the skill color based on value
        $(this).css("border-color", skillColor); // Update the circle's border color
    });

    // Function to calculate the skill color
    function calculateSkillColor(value) {
        // Define color ranges and corresponding colors
        var colorRanges = [
            { min: 0, max: 30, color: "#FF5733" },  // Red
            { min: 30, max: 60, color: "#FFA933" }, // Orange
            { min: 60, max: 100, color: "#33FF33" } // Green
        ];

        // Find the appropriate color range based on the skill value
        for (var i = 0; i < colorRanges.length; i++) {
            if (value >= colorRanges[i].min && value <= colorRanges[i].max) {
                return colorRanges[i].color;
            }
        }

        return "#e0e0e0"; // Default color if no range matches
    }
});
