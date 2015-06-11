angular.module('ionicApp', ['ionic'])

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider
      .state('signin', {
          url: '/sign-in',
          templateUrl: 'templates/sign-in.html',
          controller: 'SignInCtrl'
      })
      .state('tabs', {
          url: '/tab',
          abstract: true,
          templateUrl: 'templates/tabs.html'
      })
      .state('tabs.home', {
          url: '/home',
          views: {
              'home-tab': {
                  templateUrl: 'templates/home.html',
                  controller: 'HomeTabCtrl'
              }
          }
      })
      .state('tabs.facts', {
          url: '/facts',
          views: {
              'scoreboard-tab': {
                  templateUrl: 'templates/facts.html'
              }
          }
      })
      .state('tabs.facts2', {
          url: '/facts2',
          views: {
              'scoreboard-tab': {
                  templateUrl: 'templates/facts2.html'
              }
          }
      })
      .state('tabs.scoreboard', {
          url: '/scoreboard',
          views: {
              'scoreboard-tab': {
                  templateUrl: 'templates/scoreboard.html',
                  controller: "ScoreboardTabCtrl"
              }
          }
      })
      .state('tabs.navstack', {
          url: '/navstack',
          views: {
              'about-tab': {
                  templateUrl: 'templates/nav-stack.html'
              }
          }
      });


    $urlRouterProvider.otherwise("/sign-in");

    //window.serverUrl = "http://hmbgascoreboardserver.azurewebsites.net";
    window.serverUrl = "http://localhost:49376";

})

.controller('SignInCtrl', function ($scope, $state, $rootScope, $http) {
    this.rootScope = $rootScope;

    $scope.user = {}

    $http({
        method: 'GET',
        url: window.serverUrl + "/Players"
    }).success(function (data) {
        $scope.players = data;
    });

    $scope.signIn = function (player) {
        $rootScope.selectedPlayer = player;

        console.log('Sign-In', player);
        $state.go('tabs.home');
    };
})

.controller('HomeTabCtrl', function ($scope, $rootScope, $http) {
    console.log('HomeTabCtrl');

    $scope.stuffTest = function (player) {
        $http.post(window.serverUrl + "/Vote/" + player.PlayerId);
    };
})

.controller('ScoreboardTabCtrl', function ($scope, $rootScope, $http) {
    console.log("ScoreboardTabCtrl");

    // Get the players list with votes
    // This will be used to render a scoreboard
    // TODO figure out how to get this to fire every timee the page is loaded
    $http({
        method: "GET",
        url: window.serverUrl + "/Scoreboard"
    }).success(function(data) {
        // sort the players by vote
        $scope.players = data.sort(function (x, y) { return x.VoteCount < y.VoteCount; });
    });

});


// Not sure about this yet. I want to figure out how to display the clock and battery still
ionic.Platform.ready(function () {
    //hide the status bar using the StatusBar plugin
    if (window.StatusBar) {
        // org.apache.cordova.statusbar required
        //StatusBar.hide();
        //StatusBar.overlaysWebView(true);
        //ionic.Platform.fullScreen();
        StatusBar.styleDefault();
    }
});