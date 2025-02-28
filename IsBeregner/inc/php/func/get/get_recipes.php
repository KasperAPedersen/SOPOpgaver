<?php
    require __DIR__ . '/../../db/db_connect.php';

    session_start();

    try {
        $userID = $_SESSION['user_id'];

        $stmt = $pdo->prepare('SELECT * FROM Recipes WHERE UserID = :userID');
        $stmt->bindParam(':userID', $userID, PDO::PARAM_INT);
        $stmt->execute();
        $recipes = $stmt->fetchAll(PDO::FETCH_ASSOC);

        header('Content-Type: application/json');
        echo json_encode($recipes);
    } catch (PDOException $e) {
        echo 'Error: ' . $e->getMessage();
    }
?>