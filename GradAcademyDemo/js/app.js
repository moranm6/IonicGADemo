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
                  templateUrl: 'templates/scoreboard.html'
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
      //})
      //.state('tabs.contact', {
      //    url: '/contact',
      //    views: {
      //        'contact-tab': {
      //            templateUrl: 'templates/contact.html'
      //        }
      //    }
      });


    $urlRouterProvider.otherwise('/sign-in');

})

.controller('SignInCtrl', function ($scope, $state, $rootScope) {
    this.rootScope = $rootScope;

    $scope.user = {}
    $scope.user.username = "Test";

    $scope.signIn = function (user) {
        $rootScope.user = user;

        console.log('Sign-In', user);
        $state.go('tabs.home');
    };

})

.controller('HomeTabCtrl', function ($scope, $rootScope, $http) {
    console.log('HomeTabCtrl');

    this.rootScope = $rootScope;

    $scope.stuffTest = function (user) {
        $http.post('http://localhost:49376/Vote/' + user.username);
    };
});


ionic.Platform.ready(function () {
    //hide the status bar using the StatusBar plugin
    if (window.StatusBar) {
        // org.apache.cordova.statusbar required
        StatusBar.hide();
        ionic.Platform.fullScreen();
    }
});