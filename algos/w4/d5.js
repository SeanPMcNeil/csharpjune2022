// Queue - FIFO = First In First Out
// Use the new classes priorityNode and priorityQueue to create an enqueue method that takes priority value into consideration to properly place the item within the list

class PriNode {
    constructor(value, pri) {
        this.data = value;
        this.next = null;
        this.priority = pri;
    }
}

class PriQueue {
    constructor() {
        this.head = null;
        this.tail = null;
    }

    enqueue(val, pri) {
        var node = new PriNode(val, pri);

        if (this.head == null){
            this.head = node;
            this.tail = node;
            return this;
        }

        if (node.priority < this.head.priority){
            node.next = this.head;
            this.head = node;
            return this;
        }

        let runner = this.head;
        while (runner.next){
            if (node.priority < runner.next.priority){
                node.next = runner.next;
                runner.next = node;
                return this;
            }
            runner = runner.next;
        }

        this.tail.next = node;
        this.tail = node;
        return this;
    }

    log()
    {
        let str="";
        for(let node=this.head;node;node=node.next)
        {
            str+=node.data+"->";
        }
        console.log(str);
    }
}

const q1 = new PriQueue();

q1.enqueue(1,1).enqueue(2,2).enqueue(3,3).enqueue(3,1).enqueue(2,4).enqueue(1,2).enqueue(5,5).enqueue(8,7).enqueue(7,1);
q1.log();
