document.addEventListener("DOMContentLoaded", function () {
    const calendarGrid = document.getElementById("calendarGrid");
    const currentMonthElement = document.getElementById("currentMonth");
    const prevMonthButton = document.getElementById("prevMonth");
    const nextMonthButton = document.getElementById("nextMonth");

    let currentDate = new Date();

    function renderCalendar() {
        calendarGrid.innerHTML = "";
        const year = currentDate.getFullYear();
        const month = currentDate.getMonth();
        const firstDay = new Date(year, month, 1).getDay();
        const daysInMonth = new Date(year, month + 1, 0).getDate();

        currentMonthElement.textContent = currentDate.toLocaleDateString("en-US", {
            month: "long",
            year: "numeric"
        });

        for (let i = 0; i < firstDay; i++) {
            calendarGrid.appendChild(document.createElement("div"));
        }

        for (let day = 1; day <= daysInMonth; day++) {
            const dayElement = document.createElement("div");
            dayElement.classList.add("calendar-day");

            const dateNumber = document.createElement("span");
            dateNumber.classList.add("date-number");
            dateNumber.textContent = day;
            dayElement.appendChild(dateNumber);

            // Example tasks (Replace this with real data)
            const tasks = [
                { text: "Meeting at 10 AM", day: 5 },
                { text: "Project Deadline", day: 12 },
                { text: "Gym", day: 18 },
            ];

            tasks.forEach(task => {
                if (task.day === day) {
                    const taskElement = document.createElement("div");
                    taskElement.classList.add("task");
                    taskElement.textContent = task.text;
                    dayElement.appendChild(taskElement);
                }
            });

            calendarGrid.appendChild(dayElement);
        }
    }

    prevMonthButton.addEventListener("click", function () {
        currentDate.setMonth(currentDate.getMonth() - 1);
        renderCalendar();
    });

    nextMonthButton.addEventListener("click", function () {
        currentDate.setMonth(currentDate.getMonth() + 1);
        renderCalendar();
    });

    renderCalendar();
});
