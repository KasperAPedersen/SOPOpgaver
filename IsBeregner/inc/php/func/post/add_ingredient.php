<?php
    require_once '../../db/db_connect.php';

    header('Content-Type: application/json');

    $input = json_decode(file_get_contents('php://input'), true);

    if (!isset($input['recipeID']) || !isset($input['ingredientID']) || !isset($input['amount'])) {
        echo json_encode(['success' => false, 'error' => 'Missing recipeID, ingredientID, or amount']);
        exit;
    }

    $recipeID = $input['recipeID'];
    $ingredientID = $input['ingredientID'];
    $amount = $input['amount'];

    try {
        $query = "INSERT INTO recipe_ingredients (recipeID, ingredientID, amount) VALUES (:recipeID, :ingredientID, :amount)";
        $params = [
            ':recipeID' => $recipeID,
            ':ingredientID' => $ingredientID,
            ':amount' => $amount
        ];
        $result = UpdateData($query, $params);

        if ($result) {
            echo json_encode(['success' => true]);
        } else {
            echo json_encode(['success' => false, 'error' => 'Failed to add ingredient']);
        }
    } catch (PDOException $e) {
        echo json_encode(['success' => false, 'error' => $e->getMessage()]);
    }
?>