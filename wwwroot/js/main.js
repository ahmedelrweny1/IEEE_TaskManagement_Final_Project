const tabs = [
    { button: document.getElementById('task'), content: document.getElementById('tasks-content') },
    { button: document.getElementById('dashboard'), content: document.getElementById('dashboard-content') },
    { button: document.getElementById('supervisor'), content: document.getElementById('supervisor-content') },
    { button: document.getElementById('employee'), content: document.getElementById('employee-content') }
];

tabs.forEach(({ button, content }, index) => {
    button.addEventListener('click', (event) => {
        event.preventDefault();

        
        button.classList.add('active');
        content.classList.remove('hidden');

        
        tabs.forEach(({ button: otherButton, content: otherContent }, otherIndex) => {
            if (index !== otherIndex) {
                otherButton.classList.remove('active');
                otherContent.classList.add('hidden');
            }
        });
    });
});
