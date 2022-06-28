// Stacks
/* LIFO = Last In First Out  | FILO = First In Last Out */

class Node
{
    constructor(value)
    {
        this.next=undefined;
        this.value=value;
    }
};

class Stack
{
    constructor()
    {
        this.top=undefined;
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
        return this.top.value;
    }

    Pop()
    {
        //Code me!
        if (!this.top){
            return;
        }
        let temp = this.top;
        this.top = this.top.next;
        return temp.value;
    }

    IsEmpty()
    {
        //Code me!
        if (!this.top){
            return;
        }
        return this.top == undefined; 
    }

    Log()
    {
        let str="";
        for(let node=this.top;node;node=node.next)
        {
            str+=node.value+"->";
        }
        console.log(str);
    }
};

let stack=new Stack();
console.log(stack.IsEmpty()); /* Expected: true */
stack.Push(10);
stack.Push(20);
stack.Push(30);
stack.Push(40);
console.log(stack.IsEmpty()); /* Expected: false */
stack.Log(); /* Expected: 40->30->20->10-> */
console.log(stack.Pop()); /* Expected: 40 */
console.log(stack.Peek()); /* Expected: 30 */
console.log(stack.Pop()); /* 30 */
console.log(stack.Pop()); /* 20 */
console.log(stack.Pop()); /* 10 */
console.log(stack.IsEmpty()); /* Expected: true */