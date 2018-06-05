
//check if email address is already exists or not
eknowIdApp.directive('ngBlur', function () {
    return function (scope, elem, attrs) {
        elem.bind('blur', function () {
            if (scope.requesterForm.requesterEmail.$valid)
                scope.isUniqueEmail();
        });
    };
});

////creating custom directive
//eknowIdApp.directive('ngCompare', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, currentEl, attrs, ctrl) {
//            var comparefield = document.getElementsByName(attrs.ngCompare)[0]; //getting first element
//            compareEl = angular.element(comparefield);

//            //current field key up
//            currentEl.on('keyup', function () {
//                if (compareEl.val() != "") {
//                    var isMatch = currentEl.val() === compareEl.val();
//                    ctrl.$setValidity('compare', isMatch);
//                    scope.$digest();
//                }
//            });

//            //Element to compare field key up
//            compareEl.on('keyup', function () {
//                if (currentEl.val() != "") {
//                    var isMatch = currentEl.val() === compareEl.val();
//                    ctrl.$setValidity('compare', isMatch);
//                    scope.$digest();
//                }
//            });
//        }
//    }
//});


eknowIdApp.directive('characterOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                var transformedInput = text.replace(/[^A-Za-z]+/g, '');
                console.log(transformedInput);
                if (transformedInput !== text) {
                    ngModelCtrl.$setViewValue(transformedInput);
                    ngModelCtrl.$render();
                }
                return transformedInput;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});

eknowIdApp.directive('numberOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                var transformedInput = text.replace(/[^0-9]+/g, '');
                console.log(transformedInput);
                if (transformedInput !== text) {
                    ngModelCtrl.$setViewValue(transformedInput);
                    ngModelCtrl.$render();
                }
                return transformedInput;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});