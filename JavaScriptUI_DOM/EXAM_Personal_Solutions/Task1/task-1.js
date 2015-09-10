function solve() {
  return function (selector, isCaseSensitive) {
    var root = document.querySelector(selector);
    var isCaseSens = false;
    if(isCaseSensitive){
      isCaseSens = isCaseSensitive;
    }
    root.className += " items-control";
	
    //add-controls
    var add = document.createElement("div");
    add.className = "add-controls";
    var addInput = document.createElement("input");
    addInput.setAttribute("id", "add-input");
    var addButton = document.createElement("button");
    addButton.className = "button";
    addButton.innerHTML = "Add";
	
    addButton.addEventListener("click", function(){
      var listItemButton = document.createElement("button");
      listItemButton.className = "button";
      listItemButton.innerHTML = "X";

      var newListItem = document.createElement("li");
      newListItem.className = "list-item";
      newListItem.innerHTML += addInput.value;
      newListItem.appendChild(listItemButton);
      itemsList.appendChild(newListItem);
    });


    var addText = document.createElement("label");
    addText.innerHTML = "Enter text";
    addText.setAttribute("for", "add-input");
    var addContentLogic = document.createDocumentFragment();
    addContentLogic.appendChild(addText);
    addContentLogic.appendChild(addInput);
    addContentLogic.appendChild(addButton);
    add.appendChild(addContentLogic);

    //search-controls
    var search = document.createElement("div");
    search.className ="search-controls";

    var searchInput = document.createElement("input");
    searchInput.setAttribute("id", "search-input");
    searchInput.addEventListener("input", function(ev){
      var filterList = itemsList.getElementsByTagName("li"),
            target = ev.target.value,
            i,
            len;
      for(i = 0, len = filterList.length; i < len; i +=1){
        var currentElement = filterList[i];
        var currentInnerText = currentElement.innerHTML;
        console.log(target);
        if(isCaseSens){
          if(currentInnerText.indexOf(target) >= 0){
              currentElement.style.display = 'block';
          }
          else{
              currentElement.style.display = 'none';
          }
        }else{
          if(currentInnerText.toLowerCase().indexOf(target.toLowerCase()) >= 0){
            currentElement.style.display = 'block';
          }
          else{
            currentElement.style.display = 'none';
          }
        }

      }
    });

    var searchText = document.createElement("label");
    searchText.innerHTML = "Search";
    searchText.setAttribute("for", "search-input");
    var searchContentLogic = document.createDocumentFragment();
    searchContentLogic.appendChild(searchText);
    searchContentLogic.appendChild(searchInput);
    search.appendChild(searchContentLogic);

    //result-controls
    var result = document.createElement("div");
    result.className ="result-controls";
    var itemsList = document.createElement("ul");
    itemsList.className = "items-list";
    itemsList.addEventListener("click", function(ev){
      var target = ev.target;
      if(target.nodeName === 'BUTTON'){
        var parentNode = target.parentNode;
        itemsList.removeChild(parentNode);
      }
    });

    var resultContentLogic = document.createDocumentFragment();
    resultContentLogic.appendChild(itemsList);
    result.appendChild(resultContentLogic);

    root.appendChild(add);
    root.appendChild(search);
    root.appendChild(result);
  };
}

module.exports = solve;