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
    }
    
    // Given a value, insert that value as a node at the front of your singly linked list
    insertAtFront(val) {
        this.head = new Node(val, this.head);
        this.size++;
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
}

const ll = new SLL();

ll.insertAtBack(1);
ll.insertAtBack(9);
ll.insertAtBack(7);
ll.insertAtBack(1);
ll.insertAtFront(6);

ll.print();
console.log(ll.contains(7));
console.log(ll.contains(4));
console.log(ll.recContains(6));
console.log(ll.recContains(5));

ll.removeAtBack();
ll.print();
ll.removeAtBack();
ll.print();
console.log(ll.contains(7));