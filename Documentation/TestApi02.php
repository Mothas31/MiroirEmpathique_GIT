<?php
  require_once 'HttpClient.class.php';

  $parameters = array(
        'app_key' => '1234',
        'client_id' => '5678',
        'url' => '<URL to face image>',
        );

  $face = new HttpClient('api.sightcorp.com');
  $response = $face->post("/api/detect/", $parameters);

  echo $face->getContent();
?>
    