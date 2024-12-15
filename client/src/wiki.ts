import { WIKI_API_URL, getWikiByID, editWiki } from "./api/wiki_api";
import { Wiki } from "./types";

(async function () {
	let params = new URLSearchParams(document.location.search);
	const wikiID = params.get("id");

	if (wikiID) {
		const wikiData: Wiki = await getWikiByID(wikiID, WIKI_API_URL);
		if (wikiData) {
			populateUI(wikiData);
		} else {
			showNoResultsMessage();
		}
	}
})();

window.onclick = function(event) {
	if (event.target == modal) {
		closeModal();
	}
}

const editWikiButton = document.querySelector(".edit-wiki")!;
const saveChangesButton = document.querySelector(".save-button")!;
const closeButton = document.querySelector(".close")!;
const cancelButton = document.querySelector(".cancel-button")!;
const editWikiForm = document.getElementById("editWikiForm")!;

editWikiButton.addEventListener('click', openModal);
saveChangesButton.addEventListener('click', saveChanges);
closeButton.addEventListener('click', closeModal);
cancelButton.addEventListener('click', closeModal);
editWikiForm.addEventListener('submit', (event)=>{saveChanges(event)});

const modal = document.getElementById("editModal")!;
const wikiName = document.querySelector(".wiki-name")!;
const wikiDescription = document.querySelector(".description")!;

const newWikiName = (document.getElementById("new-wiki-name") as HTMLInputElement)!;
const newDescription = (document.getElementById("new-wiki-description") as HTMLTextAreaElement)!;

function openModal() {
	modal.style.display = "flex";
	newWikiName.value = wikiName.textContent!;
	newDescription.textContent = wikiDescription.textContent;
}

function closeModal() {
	modal.style.display = "none";
}

async function saveChanges(event: any) {
	event.preventDefault();
	const newWiki = {
		wikiName: newWikiName.value,
		description: newDescription.value
	}

	let params = new URLSearchParams(document.location.search);
	const wikiID = params.get("id");

	await editWiki(wikiID!, newWiki, WIKI_API_URL);
	wikiName.textContent = newWikiName.value;
	wikiDescription.textContent = newDescription.value;

	closeModal();
}

function populateUI(wikiData: Wiki) {
	const wikiName = document.querySelector(".wiki-name")!;
	const creatorName = document.querySelector(".creator-name")!;
	const description = document.querySelector(".description")!;

	wikiName.innerHTML = wikiData.wikiName;
	creatorName.innerHTML = "Created by: " + wikiData.creatorName;
	description.innerHTML = wikiData.description;
	
	const articleList = document.querySelector(".article-list")!;
	let articleListContent = "";

	wikiData.articles?.forEach((article)=>{
		articleListContent += `<li class="article">
			<h3>${article.articleTitle}</h3>
			<div class="article-content">
                <p>${article.articleContent.substring(0, 100)}</p>
                <a href="#" class="read-more-article">Read more</a>
            </div>
		</li>`;
	})

	articleList.innerHTML += articleListContent;
}

function showNoResultsMessage() {
	const messageBox = document.getElementById("message-box")!;
	const message = `<div class="message">
		There was a problem when creating the Wiki.
	</div>`

	messageBox.innerHTML = message;
}
