// Queue - FIFO = First In First Out

class Node
{
    constructor(val)
    {
        this.data=val;
        this.next=null;
    }
}

class Queue
{
    constructor()
    {
        this.top = null;
        // We keep track of a tail because it's how we add to the queue
        this.tail = null;
        this.size = 0;
    }

    // Push a Value into Queue (at the back) - Enqueue
    enqueue(val)
    {
        var node = new Node(val);
        if (this.isEmpty())
        {
            this.top = node;
            this.tail = node;
            this.size++;
            return this;
        }
        this.tail.next = node;
        this.tail = node;
        this.size++;
        return this;
    }

    // Pop a Value (remove from front) - Dequeue
    dequeue()
    {
        if (this.isEmpty()){
            return;
        }
        this.top = this.top.next;
        this.size--;
        return this;
    }

    // IsEmpty (return true/false)
    isEmpty()
    {
        if (!this.top){
            return true;
        }
        return false;
    }

    // Front (Does NOT remove the value)
    front()
    {
        if (this.isEmpty()){
            return "The Queue is Empty";
        }
        return this.top.data;
    }

    log()
    {
        let str="";
        for(let node=this.top;node;node=node.next)
        {
            str+=node.data+"->";
        }
        console.log(str);
    }

    // Compare 2 Queues - Using Built In Methods We Already Have (enqueue, dequeue, isEmpty, front)
    compare(otherQ)
    {
        if (this.size != otherQ.size)
        {
            return false;
        }
        let tempQ = otherQ;
        let runner = this.top;
        while (runner){
            if (runner.data == tempQ.front())
            {
                tempQ.enqueue(tempQ.front())
                tempQ.dequeue();
                runner = runner.next;
            } else {
                tempQ.enqueue(tempQ.front())
                tempQ.dequeue();
                return false;
            }
        }
        return true;
    }

    // Is this Queue a Palindrome - Using Built In Methods We Already Have (enqueue, dequeue, isEmpty, front)
    isPalindrome()
    {
        let half = Math.floor(this.size / 2);
        let full = this.size;
        let tempQ = this;
        let tempA = [];
        for (var i = 0; i < full; i++){
            if (i < half){
                tempA.push(tempQ.front());
                tempQ.dequeue();
            } else {
                console.log(tempA);
                console.log(tempQ.front());
                if (tempA[tempA.length-1] == tempQ.front()){
                    tempA.pop();
                    tempQ.dequeue();
                }
                else{
                    return false;
                }
            }
        }
        return true;
    }

    sumOfHalves() {
        if (this.isEmpty() || this.size == 1){
            return false;
        }

        let runner = this.top;
        let sum1 = 0;
        let sum2 = 0;

        for (var i = 0; i < this.size; i++){
            if (i < Math.floor(this.size / 2)){
                sum1 += runner.data;
                runner = runner.next;
            } else {
                sum2 += runner.data;
                runner = runner.next;
            }
        }

        return sum1 == sum2;

        // Set full size variable, dequeue into 2 arrays, split at the half, iterate through arrays, adding values to sums,
    }
}

class Stack
{
    constructor()
    {
        this.top=null;
    }

    Push(value)
    {
        //Code me!
        if(!this.top)
        {
            this.top = new Node(value);
            return this;
        }
        let temp = this.top;
        this.top = new Node(value);
        this.top.next = temp;
        return this;
    }

    Peek()
    {
        //Code me!
        return this.top.data;
    }

    Pop()
    {
        //Code me!
        if (!this.top){
            return;
        }
        let temp = this.top;
        this.top = this.top.next;
        return temp.data;
    }

    IsEmpty()
    {
        //Code me!
        if (!this.top){
            return;
        }
        return this.top == null; 
    }

    Log()
    {
        let str="";
        for(let node=this.top;node;node=node.next)
        {
            str+=node.data+"->";
        }
        console.log(str);
    }
}

class TwoStackQueue {
    constructor() {
        this.stack1 = new Stack();
        this.stack2 = new Stack();
    }

    enqueue(item) {
        this.stack1.Push(item);
        return this;
    }

    dequeue() {
        if (this.stack1.IsEmpty()){
            return this;
        }
        
        while (this.stack1.top){
            this.stack2.Push(this.stack1.Pop());
        }

        this.stack2.Log();

        let temp = this.stack2.Pop();
        while (this.stack2.top){
            this.stack1.Push(this.stack2.Pop());
        }

        this.stack1.Log();
        return this;
    }
}

// const q1 = new Queue();
// // const q2 = new Queue();

// q1.enqueue(1).enqueue(2).enqueue(3).enqueue(3).enqueue(2).enqueue(1).enqueue(5);
// // q1.enqueue(1).enqueue(2).enqueue(3);
// q1.log();
// console.log(q1.sumOfHalves());
// console.log(q1.isPalindrome());
// q2.enqueue(1).enqueue(2).enqueue(4);
// q2.log();
// console.log(q1.compare(q2));
// q1.log();
// q2.log();
// console.log(queue.front());
// queue.dequeue();
// queue.log();
// console.log(queue.front());
// queue.log();

const tsq = new TwoStackQueue();
tsq.enqueue(1).enqueue(2).enqueue(3);
console.log(tsq);
tsq.dequeue();
console.log(tsq);