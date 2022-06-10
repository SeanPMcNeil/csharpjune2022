class Node {
    constructor(value, next = null) {
        this.data = value;
        this.next = next;
    }
}

class SLL {
    constructor() {
        this.head = null;
        this.size = 0;
    }

    isEmpty() {
        if(this.head == null) {
            return true;
        } else {
            return false;
        }

    }

    print() {
        var arr = [];
        var runner = this.head;
        while(runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        console.log(arr);
    }

    insertAtBack(val) {
        if(this.isEmpty()){
            this.head = new Node(val);
        } else {
            var runner = this.head;
            while(runner.next) {
                runner = runner.next;
            }
            runner.next = new Node(val);
        }
        this.size++;
        return this;
    }
    
    // Given a value, insert that value as a node at the front of your singly linked list
    insertAtFront(val) {
        this.head = new Node(val, this.head);
        this.size++;
        return this;
    }
    
    // Remove and return the head node from your list (remember this means we need a new head)
    removeHead(){
        let current = this.head;
        this.head = current.next;
        this.size--;
        return current;
    }
    
    // EXTRA: calculate the average of all the values in your list (ex: if you list contained the values 3, 5, 2, 7, 3, then your average should come out as 4)
    average(){
        var runner = this.head;
        var sum = 0;
        while(runner) {
            sum += runner.data;
            runner = runner.next;
        }
        return (sum / this.size);
    }

    // Iterative Contains
    contains(val){
        var runner = this.head;
        while (runner){
            if (runner.data == val){
                return true;
            }
            runner = runner.next;
        }
        return false;
    }

    // Recursive Contains
    recContains(val, runner = this.head){
        if (runner.data == val){
            return true;
        }
        if (!runner.next) {
            return false;
        }
        return this.recContains(val, runner.next);
    }

    removeAtBack(){
        var runner = this.head;
        if (this.isEmpty()){
            return "This list is empty";
        }
        if (!runner.next){
            var temp = this.head
            this.removeHead();
            return temp;
        }
        while (runner.next.next){
            runner = runner.next;
        }
        var temp = runner.next;
        runner.next = null;
        this.size--;
        return temp;
    }

    // Return 2nd to last value in list
    getSecondToLast(){
        if (this.size < 2){
            return "This list doesn't have a second to last value";
        }
        var runner = this.head;

        while (runner.next.next){
            runner = runner.next;
        }

        return runner.data;
    }

    // Given a value, remove it if it exists
    removeValue(val){
        var runner = this.head;
        if (runner.data == val){
            this.removeHead();
            return true;
        }
        let previous;
        while (runner){
            if (runner.data == val){
                previous.next = runner.next;
                this.size--;
                return true;
            }
            previous = runner;
            runner = runner.next;
        }
        return false;
    }

    // Remove Multiple of Same Value
    removeDupeValue(val){
        var runner = this.head;
        let count = 0;
        let previous;
        
        while (runner){
            if (this.head.data == val){
                this.removeHead();
                runner = this.head;
                count++;
                continue;
            }
            if (runner.data == val){
                previous.next = runner.next;
                this.size--;
                count++;
            }

            previous = runner;
            runner = runner.next;
        }
        if (count > 0){
            return true;
        } else {
            return false;
        }
    }

    prepend(ValA, ValB) {
        let runner = this.head;
        if(runner.data == ValB){
            this.insertAtFront(ValA);
            return true;
        }
        if(this.isEmpty()){
            return false;
        }
        while(runner.next){
            if(runner.next.data == ValB){
                break;
            }
            runner = runner.next;
        }
        if(!runner.next){
            return false;
        }
        let temp = runner.next;
        runner.next = new Node(ValA, temp);
        return true;
    }

    // Given an array, concatenate the values of that array onto the back of your own (ex: if your original list contained 1, 2, 3 and the given list contained 4, 5, 6, you should now have a list that contains the values 1, 2, 3, 4, 5, 6)
    concat(array){
        for (var i = 0; i < array.length; i++){
            this.insertAtBack(array[i]);
        }
        return this;
    }

    // given a list, concatenate the values of the list onto the back of your own
    addList(list){
        let runner = list.head;
        while (runner){
            this.insertAtBack(runner);
            runner = runner.next;
        }
        return this;
    }

    // Find the smallest value in your list and move it to the front (ex: if your list looked like this: 4, 8, 2, 5, then after the function it should look like this: 2, 4, 8, 5)
    moveMinToFront(){
        let min = this.head.data;
        let runner = this.head;
        while(runner) {
            if (runner.data < min){
                min = runner.data;
            }
            runner = runner.next;
        }
        this.removeValue(min);
        this.insertAtFront(min);
    }

    // EXTRA: Given a value, split your list into two lists along that value. Ex: if your original list was 1, 2, 3, 4, 5 and you were given 3, your first list should have 1, 2 and your second list should have 3, 4, 5
    splitOnVal(val){
        if (this.contains(val)){
            if (this.head.data == val){
                return null;
            }
            let runner = this.head;
            while(runner.next.data != val) {
                runner = runner.next;
            }
            // console.log(runner.data);
            const ll2 = new SLL();
            ll2.head = runner.next;
            runner.next = null;
            return ll2;
        } else {
            return null;
        }
    }
}

const ll = new SLL();

ll.insertAtFront(3);
ll.insertAtFront(2);
ll.insertAtFront(1);
// ll.insertAtBack(1);
// ll.insertAtBack(6);
// ll.insertAtBack(3);
// ll.insertAtBack(9);

// ll.print();
// ll.moveMinToFront();
ll.print();

ll.concat([4, 5, 6])
ll.print();
var ll2 = ll.splitOnVal(4)

ll.print();
if (ll2 != null) {
    ll2.print();
}
