function() {
    var config = karate.read('classpath:environment-config.json');

    var authResult = karate.callSingle('classpath:src/Auth.feature',config);

    karate.configure('headers', {
        'Authorization': 'Bearer ' + authResult.token
    });

    return config;
}