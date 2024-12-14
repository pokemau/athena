import { ARTICLE_API_URL, getArticleByID } from "./api/article_api";
import { Article } from "./types";

(async function () {
	let params = new URLSearchParams(document.location.search);
	const articleID = params.get("id");

	if (articleID) {
		const articleData: Article = await getArticleByID(articleID, ARTICLE_API_URL);
		if (articleData) {
			populateUI(articleData);
		} else {
			showNoResultsUI();
		}
	}
})();

function populateUI(articleData: Article) {
	const cont = document.querySelector(".cont")!;

	const element = `
		<h1>${articleData.articleTitle}</h1>
		<p>${articleData.articleContent}</p>
	`;

	cont.innerHTML += element;
}

function showNoResultsUI() {
	const cont = document.querySelector(".cont")!;

	cont.innerHTML += `
		<h3>Article not found!</h3>
	`;
}
