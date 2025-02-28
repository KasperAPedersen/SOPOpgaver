let activeRecipeID = null;

document.addEventListener('DOMContentLoaded', async function () {
    await showAvailableRecipes();
    await addIngredientsToForm();
});

let showAvailableRecipes = async () => {
    let response = await fetch('inc/php/func/get/get_recipes.php');
    let data = await response.json();

    const recipesList = document.getElementById('recipe-container');
    recipesList.innerHTML = "";
    data.forEach(recipe => {
        const recipeItem = document.createElement('div');
        recipeItem.classList.add('recipe-item');
        recipeItem.innerHTML = `
                <h3 onclick='showRecipe(${recipe.RecipeID})'>${recipe.Title}</h3>
            `;
        recipesList.appendChild(recipeItem);
    });
}

document.getElementById('newRecipeForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const name = document.getElementById('new-recipe-name').value;

    try {
        let response = await fetch('inc/php/func/post/add_recipe.php', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name })
        });

        let result = await response.json();

        if (result.success) {
            await showAvailableRecipes();
        } else {
            console.error('Error:', result.error);
        }
    } catch (error) {
        console.error('Error:', error);
    }
});

let addIngredientsToForm = async () => {
    let ingredientResponse = await fetch('inc/php/func/get/get_ingredients.php');
    let ingredientData = await ingredientResponse.json();

    const ingredientSelect = document.getElementById('ingredientSelect');
    ingredientData.data.forEach(ingredient => {
        const option = document.createElement('option');
        option.value = ingredient.ingredientID;
        option.textContent = ingredient.name;
        ingredientSelect.appendChild(option);
    });
}

let showRecipe = async (recipeID) => {
    console.log("Show recipe of id: ", recipeID);
    document.getElementById('addIngredientForm').style.display = "block";
    activeRecipeID = recipeID;

    try {
        let response = await fetch(`inc/php/func/get/get_recipe_details.php?recipeID=${recipeID}`);
        let result = await response.json();

        let data = result.data;

        const container = document.querySelector('.ingredients tbody');
        container.innerHTML = '';

        data.ingredients.forEach(ingredient => {
            console.log(ingredient);
            const row = document.createElement('tr');
            row.innerHTML = `
                <td contenteditable="true" data-field="amount" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.amount}</td>
                <td data-field="Name" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.name}</td>
                <td data-field="Sugar" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.sugar}</td>
                <td data-field="Fat" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.fat}</td>
                <td data-field="FFMT" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.femt}</td>
                <td data-field="Tørstof" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.drymatter}</td>
                <td data-field="TotalDryMatter" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.total_drymatter}</td>
                <td data-field="Water" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.water}</td>
                <td data-field="PricePrKilo" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.price_per_kilo}</td>
                <td data-field="Price" data-id="${ingredient.ingredientID}" data-recipe-id="${recipeID}">${ingredient.price}</td>
                <td><button onclick="deleteRecipe(${recipeID}, ${ingredient.ingredientID})">Fjern</button></td>
            `;
            container.appendChild(row);
        });

        // Add event listeners to the editable cells
        container.querySelectorAll('td[contenteditable="true"]').forEach(cell => {
            cell.addEventListener('blur', async function () {
                const field = this.dataset.field;
                const ingredientID = this.dataset.id;
                const newValue = this.textContent;

                try {
                    await fetch('inc/php/func/put/update_ingredient.php', {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({ recipeID, ingredientID, field, newValue })
                    });
                } catch (error) {
                    console.error('Error:', error);
                }
            });
        });
    } catch(ex) {
        console.log(ex.message);
    }
}

let deleteRecipe = async (recipeID, ingredientID) => {
    try {
        await fetch('inc/php/func/delete/delete_ingredient.php', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ recipeID, ingredientID })
        });

        showRecipe(recipeID);
    } catch (error) {
        console.error('Error:', error);
    }
}

document.getElementById('addIngredientForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const recipeID = activeRecipeID; // Assuming the active recipe item has a data attribute with the recipe ID
    const ingredientID = document.getElementById('ingredientSelect').value;
    const amount = document.getElementById('ingredientAmount').value;

    try {
        await fetch('inc/php/func/post/add_ingredient.php', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ recipeID, ingredientID, amount })
        });

        showRecipe(recipeID);
    } catch (error) {
        console.error('Error:', error);
    }
});