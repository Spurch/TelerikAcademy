/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve(){
  return function (students) {

  	var studentsumOfMarks = _.map(students, function(student) {
  		var sumOfMarks = 0;
  		_.each(student.marks, function(mark) {
  			sumOfMarks += mark;
  		});
  		return {
  			firstName: student.firstName,
  			lastName: student.lastName,
  			age: student.age,
  			marks: student.marks,
  			averageMark: (sumOfMarks / student.marks.length)
  		}
  	});

  	var result = _.sortBy(studentsumOfMarks, function(student) {
  		return -student.averageMark;
  	})[0];

  	console.log(result.firstName + ' ' 
  				+ result.lastName 
  				+ ' has an average score of '
  				+ result.averageMark);
  };
}

module.exports = solve;
