import { WIKI_API_URL, createWiki } from "./api/wiki_api";
import { Wiki } from "./types";

const form = document.getElementById("createWikiForm") as HTMLFormElement;

// Ensure that the DOM is loaded before running the script
form.addEventListener("submit", async (event) => {
    event.preventDefault(); // Prevent the default form submission

    // Collect form data
    // const creatorID = (document.getElementById("creatorName") as HTMLInputElement).value;

    const newWiki = {
        wikiName: (document.getElementById("wikiName") as HTMLInputElement).value.trim(),
        creatorID: 3,
        description: (document.getElementById("wikiDescription") as HTMLTextAreaElement).value.trim()
    }

    const createdWiki = await createWiki(newWiki, WIKI_API_URL);

    if (createdWiki) {
        // Change location to new wiki
        console.log("Successfully created a new Wiki");
        location.href = `http://localhost:5173/wiki.html?id=${createdWiki.id}`;
    } else {
        showNoResultsMessage();
    }
});

function populateUI(wikiData: Wiki) {
	const cont = document.querySelector(".cont")!;

	let element = `
		<h1>${wikiData.wikiName}</h1>
		<p>${wikiData.creatorName}</p>
	`;
    wikiData.articles?.forEach((article)=>{
        element += `<div>
            <h1>${article.articleTitle}</h1>
            <p>${article.articleContent}</p>
            </div>`;   
    })

	cont.innerHTML += element;
}

function showNoResultsMessage() {
	const messageBox = document.getElementById("message-box")!;
	const message = `<div class="message">
		There was a problem when creating the Wiki.
	</div>`

	messageBox.innerHTML = message;
}