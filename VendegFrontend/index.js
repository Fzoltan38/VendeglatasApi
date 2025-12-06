document.getElementById("button1").onclick = async ()=>{

    var url = "https://localhost:7211/api/Furdok";

    var request = await fetch(url,
        {
            method : 'GET',
            headers: {'Content-Type': 'applicaton/json'}

        });
    var response = await request.json();

    console.log(response.result);
    
}