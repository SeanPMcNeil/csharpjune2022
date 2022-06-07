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
}

const ll = new SLL();

ll.insertAtBack(1);
ll.insertAtBack(9);
ll.insertAtBack(7);
ll.insertAtBack(1);
ll.insertAtFront(6);



ll.print();
console.log(ll.removeHead());
ll.print();

console.log(ll.average());