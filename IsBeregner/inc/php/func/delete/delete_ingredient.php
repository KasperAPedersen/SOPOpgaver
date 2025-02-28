<?php

require_once '../../db/db_connect.php';

header('Content-Type: application/json');

$input = json_decode(file_get_contents('php://input'), true);

if (!isset($input['recipeID']) || !isset($input['ingredientID'])) {
    echo json_encode(['success' => false, 'error' => 'Missing recipeID or ingredientID']);
    exit;
}

$recipeID = $input['recipeID'];
$ingredientID = $input['ingredientID'];

try {
    $query = "DELETE FROM recipe_ingredients WHERE recipeID = :recipeID AND ingredientID = :ingredientID";
    $params = [
        ':recipeID' => $recipeID,
        ':ingredientID' => $ingredientID
    ];
    $result = UpdateData($query, $params);

    if ($result) {
        echo json_encode(['success' => true]);
    } else {
        echo json_encode(['success' => false, 'error' => 'Failed to delete ingredient']);
    }
} catch (PDOException $e) {
    echo json_encode(['success' => false, 'error' => $e->getMessage()]);
}