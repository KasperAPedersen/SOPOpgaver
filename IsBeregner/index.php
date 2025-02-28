<?php
    session_start();

    if (!isset($_SESSION['user_id'])) {
        header('Location: /login.html');
        exit;
    }
?>

<html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Is Beregner</title>
        <link rel="stylesheet" href="inc/styling/css/index.css">
        <link rel="stylesheet" href="inc/styling/css/table.css">
    </head>
    <body>
        <header>
            <section class="name">
                <h1>Is-Beregner</h1>
            </section>
            <nav>
                <a href="#">Admin</a>
                <a href="logout.php">Logout</a>
            </nav>
        </header>

        <main>
            <aside>
                <form id="newRecipeForm" method="POST">
                    <label for="new-recipe-name">Ny Opskrift</label>
                    <input type="text" id="new-recipe-name" name="new-recipe-name" required>
                    <button type="submit">Opret</button>
                </form>
                <form id="addIngredientForm">
                    <select id="ingredientSelect" required>
                        <option value="" disabled selected>Select Ingredient</option>
                    </select>
                    <input type="number" id="ingredientAmount" placeholder="Amount (g)" required>
                    <button type="submit">Add Ingredient</button>
                </form>
                <article id="recipe-container" class="recipe-container">

                </article>
            </aside>
            <section class="content">
                <article class="info">
                    <table class="data-table">
                        <thead>
                            <tr>
                                <th>Mængde (g)</th>
                                <th>Ingredienser</th>
                                <th>Sukker (%)</th>
                                <th>Fedt (%)</th>
                                <th>FEMT (%)</th>
                                <th>Tørstof (%)</th>
                                <th>Total Tørstof (%)</th>
                                <th>Vand (%)</th>
                                <th>Pris pr kg (dkk)</th>
                                <th>Pris</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Normal</td>
                                <td>100%</td>
                                <td>14-24%</td>
                                <td>7-12%</td>
                                <td>3-10%</td>
                                <td>0.3-0.7%</td>
                                <td>32-42%</td>
                                <td>58-68%</td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Aktuel (%)</td>
                                <td>100%</td>
                                <td>0.00%</td>
                                <td>0.00%</td>
                                <td>0.00%</td>
                                <td>0.00%</td>
                                <td>0.00%</td>
                                <td>0.00%</td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Aktuel (g)</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00g</td>
                                <td>0.00 DKK/kg</td>
                                <td>0.00 DKK</td>
                            </tr>
                        </tbody>
                    </table>
                </article>

                <article class="ingredients">

                     <table class="data-table">
                        <thead>
                            <tr>
                                <th>Mængde (g)</th>
                                <th>Ingredienser</th>
                                <th>Sukker (%)</th>
                                <th>Fedt (%)</th>
                                <th>FEMT (%)</th>
                                <th>Tørstof (%)</th>
                                <th>Total Tørstof (%)</th>
                                <th>Vand (%)</th>
                                <th>Pris pr kg (dkk)</th>
                                <th>Pris</th>
                                <th>Handlinger</th>
                            </tr>
                        </thead>
                        <tbody>

                        </tbody>
                    </table>
                </article>
            </section>
        </main>

        <script src="inc/styling/js/index.js"></script>
    </body>
</html>