// Binary Search Tree

// Nodes
class Node {
    constructor(val){
        this.data = val;
        // All smaller values go to the left
        this.left = null;
        // All larger values go to the right
        this.right = null;
    }
}

class BST {
    constructor(){
        // This is the same as the SLLs head pointer
        // All trees start at the root
        this.root = null;
    }

    // Is our tree empty;
    isEmpty(){
        return this.root == null;
    }

    // We can find the min very quickly
    min(){
        var runner = this.root;
        while (runner.left){
            runner = runner.left;
        }
        return runner.data;
    }

    // We can find the max very quickly
    max(){
        var runner = this.root;
        while(runner.right){
            runner = runner.right;
        }
        return runner.data;
    }
}

var myBST = new BST();
console.log("Is my tree empty?");
console.log(myBST.isEmpty());
var node1 = new Node(30);

myBST.root = node1;

var node2 = new Node(20);
var node3 = new Node(40);
var node4 = new Node(10);
var node5 = new Node(50);

myBST.root.left = node2;
myBST.root.right = node3;
myBST.root.left.left = node4;
myBST.root.right.right = node5;
console.log("Is my tree empty?");
console.log(myBST.isEmpty());

console.log("Our minimum value is: " + myBST.min());
console.log("Our maximum value is: " + myBST.max());