
/* 
 Create a function that:
 *   Takes an array of students
 *   Each student has a `firstName` and `lastName` properties
 *   **Finds** all students whose `firstName` is before their `lastName` alphabetically
 *   Then **sorts** them in descending order by fullname
 *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
 *   Then **prints** the fullname of founded students to the console
 *   **Use underscore.js for all operations**
 */

function solve(){
    return function (students) {

        var studentsWithFullName = _.map(students, function(student){
            return {
                firstName: student.firstName,
                lastName: student.lastName,
                fullName: student.firstName + ' ' + student.lastName
            }
        });

        var firstBeforeLast = _.chain(studentsWithFullName).filter(function(student) {
            return student.firstName < student.lastName;
        }).sortBy('fullName').value().reverse()

        _.each(firstBeforeLast, function(student){
            console.log(student.fullName)
        });
    };
}

module.exports = solve;