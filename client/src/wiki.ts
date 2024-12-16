import { WIKI_API_URL, getWikiByID, editWiki, deleteWiki } from "./api/wiki_api";
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

const modals = document.querySelectorAll(".modal") as NodeListOf<HTMLElement>;
const wikiName = document.querySelector(".wiki-name")!;
const wikiDescription = document.querySelector(".description")!;

const newWikiName = (document.getElementById("new-wiki-name") as HTMLInputElement)!;
const newDescription = (document.getElementById("new-wiki-description") as HTMLTextAreaElement)!;	
const editWikiButton = document.querySelector(".edit-wiki")!;
const deleteWikiButton = document.querySelector(".delete-wiki")!;
const saveChangesButton = document.querySelector(".save-button")!;
const confirmDeleteButton = document.querySelector(".delete-button")!;
const closeButtons = document.querySelectorAll(".close") as NodeListOf<HTMLElement>;
const cancelButtons = document.querySelectorAll(".cancel-button") as NodeListOf<HTMLElement>;
const editWikiForm = document.getElementById("edit-wiki-form")!;

editWikiButton.addEventListener('click', openEditModal);
deleteWikiButton.addEventListener('click', openDeleteModal);
saveChangesButton.addEventListener('click', saveChanges);
confirmDeleteButton.addEventListener('click', deleteWikiFinal);
closeButtons.forEach((button)=>{
	button.addEventListener('click', closeModal);
})
cancelButtons.forEach((button)=>{
	button.addEventListener('click', closeModal);
})
editWikiForm.addEventListener('submit', (event)=>{saveChanges(event)});

function openEditModal() {
	const editModal = document.getElementById("edit-modal")!;
	editModal.style.display = "flex";
	newWikiName.value = wikiName.textContent!;
	newDescription.textContent = wikiDescription.textContent;
}
function openDeleteModal() {
	const deleteModal = document.getElementById("delete-modal")!;
	deleteModal.style.display = "flex";
}

function closeModal() {
	modals.forEach(modal => {
		console.log(modal);
        modal.style.display = "none";
    });
}

window.onclick = function(event) {
	modals.forEach(modal => {
        if (event.target === modal) {
            closeModal();
        }
    });
}

async function saveChanges(event: any) {
	event.preventDefault();
	const newWiki = {
		wikiName: newWikiName.value,
		description: newDescription.value
	}

	let params = new URLSearchParams(document.location.search);
	const wikiID = params.get("id");

	const result = await editWiki(wikiID!, newWiki, WIKI_API_URL);

	if (result){
		wikiName.textContent = newWikiName.value;
		wikiDescription.textContent = newDescription.value;
	}
	else{
		const messageBox = document.getElementById("message-box")!;
		const message = `<div class="message">
			There was a problem when editing the Wiki.
		</div>`
		messageBox.innerHTML = message;
	}

	closeModal();
}

async function deleteWikiFinal(){
	let params = new URLSearchParams(document.location.search);
	const wikiID = params.get("id");

	const result = await deleteWiki(wikiID!, WIKI_API_URL);

	if (result){
		wikiName.textContent = newWikiName.value;
		wikiDescription.textContent = newDescription.value;
		location.href = "http://localhost:5173";
	}
	else{
		const messageBox = document.getElementById("message-box")!;
		const message = `<div class="message">
			There was a problem when editing the Wiki.
		</div>`
		messageBox.innerHTML = message;
		closeModal();
	}
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
	const wikiName = document.querySelector(".wiki-name")!;
	wikiName.innerHTML = "This wiki does not exists..."
	
	const messageBox = document.querySelector(".message-box") as HTMLElement;
	const message = `<div class="message">
		There was a problem when creating the Wiki.
	</div>`

	messageBox.innerHTML = message;
	setTimeout(function() {
		messageBox.style.display = 'none';
	}, 3000);  // Fully hidden after 3 seconds
}
