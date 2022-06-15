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
        if (this.isEmpty()){
            return "This list is empty";
        }
        var runner = this.root;
        while (runner.left){
            runner = runner.left;
        }
        return runner.data;
    }

    // We can find the max very quickly
    max(){
        if (this.isEmpty()){
            return "This list is empty";
        }
        var runner = this.root;
        while(runner.right){
            runner = runner.right;
        }
        return runner.data;
    }

    contains(val){
        if (this.isEmpty()){
            return false;
        }
        var runner = this.root;
        while (runner){
            if (val == runner.data){
                return true;
            } else if (val < runner.data) {
                runner = runner.left;
            } else {
                runner = runner.right;
            }
        }
        return false;
    }

    recContains(val, runner = this.root){
        if (this.isEmpty()){
            return false;
        }
        if (val == runner.data) {
            return true;
        }
        if (!runner.left && !runner.right) {
            return false;
        } 
        if (val < runner.data) {
            return this.recContains(val, runner.left);
        } else {
            return this.recContains(val, runner.right);
        }
    }

    range(){
        if (this.isEmpty()){
            return "This list is empty";
        }
        return this.max() - this.min();
    }

    insert(val){
        if (this.isEmpty()){
            myBST.root = new Node(val);
        } else {
            var runner = this.root;
            while (runner.left && runner.right) {
                if (val > runner.data){
                    runner = runner.right;
                } else {
                    runner = runner.left;
                }
            }
            if (val > runner.data){
                runner.right = new Node(val);
            } else {
                runner.left = new Node(val);
            }
        }
        return this;
    }

    recInsert(val, runner = this.root, prevRunner = this.root){
        if (this.isEmpty()){
            this.root = new Node(val);
            return this;
        }
        if (runner){
            if (val > runner.data){
                return this.recInsert(val, runner.right, runner);
            } else{
                return this.recInsert(val, runner.left, runner);
            }
        }
        if (val > prevRunner.data){
            prevRunner.right = new Node(val);
        } else {
            prevRunner.left = new Node(val);
        }
        return this;
    }
}

var myBST = new BST();
// console.log("Is my tree empty?");
// console.log(myBST.isEmpty());
// var node1 = new Node(30);

// myBST.root = node1;

// var node2 = new Node(20);
// var node3 = new Node(40);
// var node4 = new Node(10);
// var node5 = new Node(50);

// myBST.root.left = node2;
// myBST.root.right = node3;
// myBST.root.left.left = node4;
// myBST.root.right.right = node5;
// console.log("Is my tree empty?");
// console.log(myBST.isEmpty());

// console.log("Our minimum value is: " + myBST.min());
// console.log("Our maximum value is: " + myBST.max());
// console.log("Our range is: " + myBST.range());

// console.log(myBST.contains(60));
// console.log(myBST.contains(50));
// console.log(myBST.contains(5));

// console.log(myBST.recContains(30));
// console.log(myBST.recContains(50));
// console.log(myBST.recContains(5));

myBST.insert(30).insert(10).insert(40).insert(20).insert(31);
// myBST.recInsert(30).recInsert(10).recInsert(40).recInsert(20).recInsert(31);

// console.log(myBST.contains(31));

// myBST.recInsert(60);
// console.log(myBST.contains(60));