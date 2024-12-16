import { WIKI_API_URL, createWiki } from "./api/wiki_api";
import { ARTICLE_API_URL, createArticle } from "./api/article_api";
import { Article, ArticleCreate, Wiki } from "./types";

const form = document.getElementById("createWikiForm") as HTMLFormElement;

// Ensure that the DOM is loaded before running the script
form.addEventListener("submit", async (event) => {
	event.preventDefault(); // Prevent the default form submission

	// Collect form data
	// const creatorID = (document.getElementById("creatorName") as HTMLInputElement).value;

	let params = new URLSearchParams(document.location.search);
	const wikiID = Number(params.get("id"));
	const userID = localStorage.getItem("userId")?.toString()!;

	const newArticle: ArticleCreate = {
		wikiID: wikiID,
		creatorID: userID,
		articleTitle: (document.getElementById("wikiName") as HTMLInputElement).value.trim(),
		articleContent: (
			document.getElementById("wikiDescription") as HTMLTextAreaElement
		).value.trim(),
	};

	await createArticle(wikiID.toString(), ARTICLE_API_URL, newArticle);
	location.reload();
});

function populateUI(wikiData: Wiki) {
	const cont = document.querySelector(".cont")!;

	let element = `
		<h1>${wikiData.wikiName}</h1>
		<p>${wikiData.creatorName}</p>
	`;
	wikiData.articles?.forEach((article) => {
		element += `<div>
            <h1>${article.articleTitle}</h1>
            <p>${article.articleContent}</p>
            </div>`;
	});

	cont.innerHTML += element;
}

function showNoResultsMessage() {
	const messageBox = document.querySelector(".message-box") as HTMLElement;
	const message = `<div class="message">
		There was a problem when creating the Wiki.
	</div>`;

	messageBox.innerHTML = message;

	setTimeout(function () {
		messageBox.style.display = "none";
	}, 3000); // Fully hidden after 3 seconds
}
