document.getElementById('load-data').addEventListener('click', function() {
    const table = document.getElementById('data-table');
    table.innerHTML = '';

    fetch('https://localhost:7073/api/Product/GetWithCategory')
        .then(response => response.json())
        .then(data => {
            const thead = document.createElement('thead');
            const trHead = document.createElement('tr');
            
            Object.keys(data[0]).forEach((key) => {
                trHead.innerHTML += `<th>${key}</th>`
            });

            thead.append(trHead);

            const tbody = document.createElement('tbody');

            data.forEach(item => {
                const tr = document.createElement('tr');

                Object.values(item).forEach(value => {
                    tr.innerHTML += `<td>${value}</td>`;
                });

                tbody.append(tr);
            });

            table.append(thead);
            table.append(tbody);
        }).catch(error => console.error('Error:', error));
});