function translateGender(gender) {
  switch (gender) {
    case "male":
      return "Masculino";
    case "female":
      return "Feminino";
    default:
      return "Não especificado";
  }
}

async function fetchUsers() {
  try {
    const response = await fetch("http://localhost:5289/api/users");
    const users = await response.json();
    const tableBody = document.querySelector("#userTable tbody");
    tableBody.innerHTML = "";

    users.forEach((user) => {
      const row = document.createElement("tr");
      row.innerHTML = `
                <td><img src="${user.picture.thumbnail}" alt="Foto"></td>
                <td>${user.name.first}</td>
                <td>${translateGender(user.gender)}</td>
                <td>${user.dob.age}</td>
                <td>${user.email}</td>
                <td>${user.nat}</td>
            `;
      tableBody.appendChild(row);
    });
  } catch (error) {
    console.error("Erro ao buscar os dados:", error);
  }
}

window.onload = fetchUsers;
