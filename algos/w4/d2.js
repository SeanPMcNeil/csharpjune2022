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
    }

    // Push a Value into Queue (at the back) - Enqueue
    enqueue(val)
    {
        var node = new Node(val);
        if (this.isEmpty())
        {
            this.top = node;
            this.tail = node;
            return this;
        }
        this.tail.next = node;
        this.tail = node;
        return this;
    }

    // Pop a Value (remove from front) - Dequeue
    dequeue()
    {
        if (this.isEmpty()){
            return;
        }
        this.top = this.top.next;
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
}

const queue = new Queue();

queue.enqueue(1).enqueue(2).enqueue(3);
queue.log();
console.log(queue.front());
queue.dequeue();
queue.log();
console.log(queue.front());
queue.log();
