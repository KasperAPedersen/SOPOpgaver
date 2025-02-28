<?php
    require __DIR__ . '/../../db/db_connect.php';

    session_start();

    try {
        // Get the user ID from the session
        $userID = $_SESSION['user_id'];

        // Prepare the SQL statement with a WHERE clause
        $stmt = $pdo->prepare('SELECT * FROM Recipes WHERE UserID = :userID');
        // Bind the user ID parameter
        $stmt->bindParam(':userID', $userID, PDO::PARAM_INT);
        // Execute the statement
        $stmt->execute();
        // Fetch all recipes for the specific user
        $recipes = $stmt->fetchAll(PDO::FETCH_ASSOC);

        // Output the recipes as JSON
        header('Content-Type: application/json');
        echo json_encode($recipes);
    } catch (PDOException $e) {
        // Handle any errors
        echo 'Error: ' . $e->getMessage();
    }
?>