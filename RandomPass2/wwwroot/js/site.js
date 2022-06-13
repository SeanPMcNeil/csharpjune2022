// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
genpass.onclick = async () => {
    const result = new Promise(function(resolve){
        let req = new XMLHttpRequest();
        req.open('GET', "http://localhost:5153/Password");
        req.onload = function() {
            if (req.status == 200){
                resolve(req.response);
            } else {
                resolve("File not found");
            }
        };
        req.send();
    });
    document.getElementById("passfield").innerHTML = await result;

    // console.log(result);
    // passfield.innerHTML = result;
}

// feedBtn.onclick = async () => {
//     const result = await fetch ("http://localhost:5098/Home/Feed");
//     const messageResult = await result.json();
//     message.innerHTML = messageResult;
//     updateStats();
//     checkWin();
// }

// {/* <button onclick={ feedbtn.onclick() }>Feed</button> */}