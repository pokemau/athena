import { ARTICLE_API_URL, deleteArticle, getArticleByID, updateArticle } from "./api/article_api";
import { Article, ArticleUpdate } from "./types";

let ARTICLE: Article;
const articleTitle = document.querySelector(".article-details__title")!;
const articleCreator = document.querySelector(".article-details__creator")!;
const articleContent = document.querySelector(".article-content")!;
const wikiTitle: HTMLAnchorElement = document.querySelector(".wiki-title")!;

(async function () {
	let params = new URLSearchParams(document.location.search);
	const articleID = params.get("id");

	if (articleID) {
		const articleData: Article = await getArticleByID(articleID, ARTICLE_API_URL);
		ARTICLE = articleData;
		if (articleData) {
			populateUI(articleData);
		} else {
			showNoResultsUI();
		}
	}
})();

function populateUI(articleData: Article) {
	articleTitle.textContent = articleData.articleTitle;
	articleCreator.textContent = `Written by: pokemau`;
	articleContent.textContent = articleData.articleContent;
	wikiTitle.textContent = articleData.wikiName;
	wikiTitle.href = `./wiki.html?id=${articleData.wikiID}`;
}

function showNoResultsUI() {
	const cont = document.querySelector(".cont")!;

	cont.innerHTML = `
		<h3>Article not found!</h3>
	`;
}

const modal = document.getElementById("myModal")!;
const span = document.getElementsByClassName("close")[0]!;
const editBtn = document.querySelector(".edit-btn")!;
const deleteBtn = document.querySelector(".delete-btn")!;
const saveBtn = document.querySelector(".save-edit-btn")!;

const titleInput: HTMLInputElement = document.querySelector("#title-input")!;
const contentInput: HTMLInputElement = document.querySelector("#content-input")!;

if (saveBtn) {
	saveBtn.addEventListener("click", async (e) => {
		e.preventDefault();

		const articleUpdate: ArticleUpdate = {
			articleContent: contentInput.value,
			articleTitle: titleInput.value,
		};

		await updateArticle(ARTICLE.id.toString(), ARTICLE_API_URL, articleUpdate);
		articleTitle.textContent = titleInput.value;
		articleContent.textContent = contentInput.value;
		modal.style.display = "none";
	});
}

deleteBtn.addEventListener("click", async (e) => {
	e.preventDefault();

	let params = new URLSearchParams(document.location.search);
	const articleID = Number(params.get("id"));

	await deleteArticle(articleID);
});

editBtn.addEventListener("click", (e) => {
	e.preventDefault();
	modal.style.display = "block";
	titleInput.value = ARTICLE.articleTitle;
	contentInput.value = ARTICLE.articleContent;
});
span.addEventListener("click", () => {
	modal.style.display = "none";
});

window.onclick = function (event) {
	if (event.target == modal) {
		modal.style.display = "none";
	}
};
