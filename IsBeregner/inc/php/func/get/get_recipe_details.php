<?php
require __DIR__ . '/../../db/db_connect.php';

session_start();

header('Content-Type: application/json');

try {
    // Check if recipeID is provided and is a valid integer
    if (!isset($_GET['recipeID']) || !filter_var($_GET['recipeID'], FILTER_VALIDATE_INT)) {
        throw new Exception('Invalid or missing recipe ID');
    }

    $recipeID = (int)$_GET['recipeID'];

    // Prepare the SQL statement to fetch recipe details
    $stmt = $pdo->prepare('SELECT * FROM Recipes WHERE RecipeID = :recipeID');
    $stmt->bindParam(':recipeID', $recipeID, PDO::PARAM_INT);
    $stmt->execute();
    $recipe = $stmt->fetch(PDO::FETCH_ASSOC);

    if (!$recipe) {
        throw new Exception('Recipe not found');
    }

    // Prepare the SQL statement to fetch ingredients for the recipe
    $stmt = $pdo->prepare('
        SELECT i.ingredientID, i.name, ri.amount, i.sugar, i.fat, i.femt, i.drymatter,
               i.total_drymatter, i.water, i.price_per_kilo, i.price
        FROM recipe_ingredients ri
        JOIN ingredients i ON ri.ingredientID = i.ingredientID
        WHERE ri.recipeID = :recipeID
    ');
    $stmt->bindParam(':recipeID', $recipeID, PDO::PARAM_INT);
    $stmt->execute();
    $ingredients = $stmt->fetchAll(PDO::FETCH_ASSOC);

    // Combine recipe details and ingredients
    $recipe['ingredients'] = $ingredients;

    // Output the recipe details and ingredients as JSON
    echo json_encode(['success' => true, 'data' => $recipe]);

} catch (Exception $e) {
    // Handle any errors
    http_response_code(400);
    echo json_encode(['success' => false, 'error' => $e->getMessage()]);
} catch (PDOException $e) {
    // Handle database errors
    http_response_code(500);
    echo json_encode(['success' => false, 'error' => 'Database error occurred']);
    // Log the actual error message for debugging (don't expose it to the client)
    error_log('Database error: ' . $e->getMessage());
}
?>
