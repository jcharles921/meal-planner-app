const saveButton = document.getElementById('save-button');
saveButton.addEventListener('click', () => {
    const schedule = [];
    document.querySelectorAll('.day').forEach(day => {
        const dayName = day.dataset.day;
        const meals = Array.from(day.querySelectorAll('.meal')).map(meal => meal.dataset.mealId);
        schedule.push({ day: dayName, meals: meals });
    });

    const csrfToken = document.querySelector('input[name="__RequestVerificationToken"]').value;
    fetch('@Url.Page("WeeklyCalendar")', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': csrfToken
        },
        body: JSON.stringify(schedule)
    }).then(response => {
        if (response.ok) {
            // Animation for Save Confirmation
            const confirmation = document.createElement('div');
            confirmation.textContent = 'Schedule Saved!';
            confirmation.style.cssText = `
                position: fixed;
                bottom: 10px;
                right: 10px;
                background: #198754;
                color: white;
                padding: 1rem;
                border-radius: 5px;
                box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
                animation: fadeOut 3s forwards;
            `;
            document.body.appendChild(confirmation);

            setTimeout(() => {
                confirmation.remove();
            }, 3000);
        } else {
            alert('Failed to save schedule.');
        }
    });
});

/* CSS for fadeOut */
const style = document.createElement('style');
style.textContent = `
    @keyframes fadeOut {
        0% { opacity: 1; }
        100% { opacity: 0; transform: translateY(20px); }
    }
`;
document.head.appendChild(style);

saveButton.addEventListener('click', () => {
    const schedule = [];
    document.querySelectorAll('.day').forEach(day => {
        const dayName = day.dataset.day;
        const meals = Array.from(day.querySelectorAll('.meal')).map(meal => meal.dataset.mealId);
        schedule.push({ day: dayName, meals: meals });
    });

    const csrfToken = document.querySelector('input[name="__RequestVerificationToken"]').value;
    fetch('@Url.Page("WeeklyCalendar")', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': csrfToken
        },
        body: JSON.stringify(schedule)
    }).then(response => {
        if (response.ok) {
            // Animation for Save Confirmation
            const confirmation = document.createElement('div');
            confirmation.textContent = 'Schedule Saved!';
            confirmation.style.cssText = `
                position: fixed;
                bottom: 10px;
                right: 10px;
                background: #198754;
                color: white;
                padding: 1rem;
                border-radius: 5px;
                box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
                animation: fadeOut 3s forwards;
            `;
            document.body.appendChild(confirmation);

            setTimeout(() => {
                confirmation.remove();
            }, 3000);
        } else {
            alert('Failed to save schedule.');
        }
    });
});

/* CSS for fadeOut */
const style = document.createElement('style');
style.textContent = `
    @keyframes fadeOut {
        0% { opacity: 1; }
        100% { opacity: 0; transform: translateY(20px); }
    }
`;
document.head.appendChild(style);
