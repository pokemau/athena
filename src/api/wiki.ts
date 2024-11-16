// Fetch articles from a wiki
// Fetch wiki content from an article in a wiki

import { Article, gameArticles, schoolArticles, Wiki } from "./testdata";
import { wikis } from "./testdata";

// WIKI
// -- ARTICLE
// -- ARTICLE
// -- ARTICLE
// -- ARTICLE

function loadWikiData(wikiTitle: string): Wiki {
	console.log(`GETTING WIKI NAME ${wikiTitle}`);

	const res = wikis.find((w) => w.title.toLowerCase() === wikiTitle.toLowerCase());
	if (!res) {
		throw new Error("err");
	} else {
		return res;
	}
}

function loadArticleData(wikiName: string, articleID: number): Article {
	console.log(`GETTING ARTICLE ${articleID} FROM WIKI ${wikiName}`);
	let articles;
	if (wikiName === "games") articles = gameArticles;
	else articles = schoolArticles;

	const res = articles.find((a) => a.id === articleID);
	console.log(res);

	if (!res) {
		throw new Error("err");
	} else {
		return res;
	}
	// get article from wiki
}

export { loadArticleData, loadWikiData };
