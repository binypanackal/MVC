





var DoExpencesApp = angular.module('DoExpencesApp', ['ngRoute']);


//Defining Controller

DoExpencesApp.controller('taskListCtrl', function ($scope, $http) {
        $http.get('/api/task/').success(function (data) {
            $scope.taskList = data;
        });

        $scope.SelectRow = function (rowNumber) {
            $scope.selectedRow = rowNumber;
        };

});

DoExpencesApp.controller('task', function ($scope, $http) {
    
    var CategoryID = 1;
    var Description = "";
    var SheduledDate = "";
    var Expence=""
    var TaskStatus = 1;

    $scope.save = function (obj) {

        var task = {
            "CategoryID": CategoryID,
            "Description": obj.Description,
            "SheduledDate": obj.SheduledDate,
            "Expence": obj.Expence,
            "TaskStatus": TaskStatus
        };
        
        $http.put('/api/task/', task).success(function (data) {
            alert("Saved Successfully!!");
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving posts! " + data;
            $scope.loading = false;
        });
    };

    
    $scope.CompleteTask = function (obj) {
        

        alert("CompleteTask");
        
        //var taskList = obj;
        //$('input:checked').each(function () {

        //    var temp = new Object();
        //    temp["TaskID"] = $(this).attr("taskId");
        //    temp["CompletedTaskID"] = "";
        //    temp["CompletedDate"] = "";
        //    temp["SheduledDate"] = "";
        //    temp["DifferenceMargin"] = "";
        //    temp["CreateDate"] = "";

        //    jsonObj.push(temp)
        //});



        //var task = {
        //    "CategoryID": CategoryID,
        //    "Description": obj.Description,
        //    "SheduledDate": obj.SheduledDate,
        //    "Expence": obj.Expence,
        //    "TaskStatus": TaskStatus
        //};


        //$http.put('/api/task/', task).success(function (data) {
        //    alert("Saved Successfully!!");
        //}).error(function (data) {
        //    $scope.error = "An Error has occured while Saving posts! " + data;
        //    $scope.loading = false;
        //});
    };

});


//routing
DoExpencesApp.config(function ($routeProvider) {
    $routeProvider.
         when('/Tasks', {
                templateUrl: 'Task',
                controller: 'taskListCtrl'
         }).
        when('/CreateTask', {
            templateUrl: 'Task/CreateTask',
            controller: 'task'
        });
    });



// LOGIN
$(document).ready(function () {

    //registration 
    $('#registerLink').on('click', function () {
        

        $('#userRegistrationForm').dialog({
            position: {
                my: 'center ',
                at: 'center',
                of: $("#main-container"),
            },
            autoOpen: false,
            modal: true,
            title: "Register User",
            width: 465,
            height: 375,
            resizable: false,

        });


        $.ajax({
            //Call GetInstructorList action method
            url: "/Login/Register",
            type: 'Get',
            success: function (data) {
                $("#userRegistrationForm").html(data);
                $(document).on('click', '#createUser', createUserClick);
            
            }
        });

        $("#userRegistrationForm").dialog("open");
        $('.ui-widget-overlay').css('background', 'black');
        return false;
    });

    var createUserClick = function () {

        var userData = {
            UserName: $("#UserName").val(),
            Password: $("#Password").val(),
            FirstName: $("#FirstName").val(),
            LastName: $("#LastName").val(),
            EmaillID: $("#EmaillID").val(),
        };

        $.ajax({
            //Call GetInstructorList action method
            url: "/Login/Register",
            type: 'post',
            data:userData,
            success: function (data) {
                $("#userRegistrationForm").dialog("close");
                alert("User Created Sucessfully, You can login to the system now");
                $('#loginLink').click();
            }
        });
    }

    //Login
    $('#loginLink').on('click', function () {

        $('#userRegistrationForm').dialog({
            position: {
                my: 'center ',
                at: 'center',
                of: $("#main-container"),
            },
            autoOpen: false,
            modal: true,
            title: "Login",
            width: 465,
            height: 250,
            resizable: false,

        });

        $.ajax({
            //Call GetInstructorList action method
            url: "/Login/Login",
            type: 'Get',
            success: function (data) {
                $("#userRegistrationForm").html(data);
                $(document).on('click', '#login', loginClick);

            }
        });

        $("#userRegistrationForm").dialog("open");
        $('.ui-widget-overlay').css('background', 'black');
        return false;
    });
    
    var loginClick = function () {
        $("form").validate(null)
        $("form").valid();
        
        var logindata = {
            UserName:$("#UserName").val(),
            Password: $("#Password").val(),
        };
        $.ajax({
            url: "/Login/Login",
            type: 'POST',
            data:logindata,
            success: function (data) {
                $("#userRegistrationForm").dialog("close");
                window.location.href = data.redirectToUrl;
            },
            error:function(e)
            {
                alert(e.responseText);
            }
        });


    
        return false;
    }


    //log Off
    $('#logOffLink').on('click', function () {
        $.ajax({
            url: "/Login/LogOff",
            type: 'Get',
            success: function (data) {
                alert("Logged out");
                window.location.href = data.redirectToUrl;
            }
        });
    });
});

