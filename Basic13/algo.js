// Print 1-255
for (var i = 1; i <= 255; i++){
    console.log(i);
}

// Print Odd Numbers 1-255
for (var i = 1; i <= 255; i++){
    if (i % 2 != 0){
        console.log(i);
    }
}



// Eliminate Negatives
var numArray = [1, 5, 10, -2];
console.log(numArray);

for (var i = 0; i < numArray.length; i++){
    if (numArray[i] < 0){
        numArray[i] = 0;
    }
}

console.log(numArray);

