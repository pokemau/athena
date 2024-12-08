import { Article, Wiki } from "./api/testdata";
import { loadWikiData, loadArticleData } from "./api/wiki";

let params = new URLSearchParams(document.location.search);

const wiki = params.get("wiki");
const article = params.get("article");

if (wiki) {
	try {
		if (article) {
			const articleData = loadArticleData(wiki, Number(article));
			populateArticle(articleData);
		} else {
			const wikiData = loadWikiData(wiki);
			populateWiki(wikiData);
		}
	} catch (error) {
		console.error(error);
	}
}

function populateWiki(wikiData: Wiki) {
	const cont = document.querySelector(".cont");
	if (!cont) return;

	const wikiHTML = `
    <h1 class="wiki__title">${wikiData.title}</h1>
    <p class="wiki__description">${wikiData.description}</p>
    <div>
      <h3>Articles</h3>
      <ul class="wiki__articles">
      </ul>
    </div>
  `;

	cont.innerHTML += wikiHTML;

	const articlesCont = document.querySelector(".wiki__articles");
	if (!articlesCont) return;

	for (let i = 0; i < wikiData.articles.length; i++) {
		const article = wikiData.articles[i];
		const newelem = `
        <li>
          <a href="/wiki.html?wiki=${wiki}&article=${article.id}">${article.title}</a>
        </li>
      `;
		articlesCont.innerHTML += newelem;
	}
}

function populateArticle(articleData: Article) {
	const cont = document.querySelector(".cont");
	if (!cont) return;

	const articleHTML = `
    <h1 class="article__title">${articleData.title}</h1>
    <p class="article__description">${articleData.content}</p>
  `;
	cont.innerHTML += articleHTML;
}
