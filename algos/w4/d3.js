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
}

const q1 = new Queue();
const q2 = new Queue();

q1.enqueue(1).enqueue(2).enqueue(3).enqueue(4).enqueue(2).enqueue(1);
// q1.enqueue(1).enqueue(2).enqueue(3);
q1.log();
console.log(q1.isPalindrome());
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
