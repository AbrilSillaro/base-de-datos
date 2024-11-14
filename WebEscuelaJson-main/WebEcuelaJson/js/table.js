const $$DomTable = function () {
    this.row = function (parent) {
        const row = $dc.createAndAppend(parent, "tr");
        return row;
    };
    this.dataCell = function (parent) {
        const dataCell = $dc.createAndAppend(parent, "td"); // Data cell
        return dataCell;
    };
    this.headerCell = function (parent) {
        const headerCell = $dc.createAndAppend(parent, "th"); // Header cell
        return headerCell;
    };

    this.createTable = function () {
        const containerMain = $d.querySelector("main")
        const containerTable = $dc.div(containerMain);
        containerTable.classList.add("container__table");
        const table = $dc.createAndAppend(containerTable, "table");
    };
    this.createThead = function () {
        const table = $d.querySelector("table");
        const tableHeader = $dc.createAndAppend(table, "thead");
        tableHeader.classList.add("tableHeader");
        return tableHeader;
    };
    this.createTbody = function () {
        const table = $d.querySelector("table");
        const tbody = $dc.createAndAppend(table, "tbody");
    };

    this.table = function (listTitles, data) {
        if (data.length !== 0) {
            this.createTable();
            this.createThead();
            this.createTbody();
            this.addTheadTitle(listTitles);
            this.addTbodyItem(data);

        } else {
            return;
        }
    };

    this.addTheadTitle = function (listTitles) {
        tableHeader = $d.querySelector("thead");
        const headerRow = this.row(tableHeader);
        listTitles.forEach((title) => {
            const headerCell = this.headerCell(headerRow);
            headerCell.textContent = title;
        });
        const deleteHeaderCell = this.headerCell(headerRow);
        deleteHeaderCell.classList.add()
        deleteHeaderCell.textContent = "Borrar";
        const editHeaderCell = this.headerCell(headerRow);
        editHeaderCell.textContent = "Modificar";
    };

    this.addTbodyItem = function (data) {
        const tbody = $d.querySelector("tbody");
        data.forEach((userData) => {
            const row = this.row(tbody);

            Object.entries(userData).forEach(([key, value]) => {
                const cell = this.dataCell(row);
                cell.textContent = value;
            });
            const deleteCell = this.dataCell(row);
            const deletIcon = this.createDeleteIcon(deleteCell);
            const editCell = this.dataCell(row);
            const editIcon = this.createEditIcon(editCell);


        });
    };

    this.createDeleteIcon = function (parent) {
        const icono = $dc.icono(parent, "bi-trash3-fill");
        icono.classList.add("tr__icono--delet");
        icono.addEventListener("click", deletUser);

    };
    this.createEditIcon = function (parent) {
        const icono = $dc.icono(parent, "bi-pencil-square");
        icono.classList.add("tr__icono--edit");
        icono.addEventListener("click", modifyUser);

    };
    function deletUser(e) {
        const tr = this.parentNode.parentNode;
        const tds = tr.querySelectorAll("td");
        const id = tds[0];

        let fd = new FormData();
        fd.append("accion", "DELETEUSER");
        fd.append("ID", id.textContent);

        const res = Post(fd);
        if (res !== "OK") alert(res);
        $f.addUser();

    }
    function modifyUser() {
        const tr = this.parentNode.parentNode;
        const tds = tr.querySelectorAll('td');
        const id = tds[0].textContent;
        const nombre = tds[1].textContent;
        const dni = tds[2].textContent;
        const mail = tds[3].textContent;

        const user = {
            ID: id,
            Nombre: nombre,
            Dni: dni,
            Mail: mail
        };
        $f.modifyUser(user);


    };
};
const $dt = new $$DomTable();
