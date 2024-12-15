import { ArticleUpdate } from "../types";

const ARTICLE_API_URL = "https://localhost:7177/api/articles";

async function getArticles() {}

async function getArticleByID(ID: string, API_URL: string) {
	try {
		const response = await fetch(`${API_URL}/${ID}`, {
			method: "GET",
		});

		const data = await response.json();
		if (data) {
			return data;
		}
		return null;
	} catch (error) {
		console.error(`getArticleByID ||||| ${error}`);
	}
}

async function updateArticle(ID: string, API_URL: string, articleUpdate: ArticleUpdate) {
	try {
		const res = await fetch(`${API_URL}/${ID}`, {
			method: "PUT",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify(articleUpdate),
		});
		if (!res.ok) {
			console.log("ERROROROROROR");
		}
		const data = res.json();

		console.log(data);
	} catch (error) {
		console.error(`updateArticle ||||| ${error}`);
	}
}

export { ARTICLE_API_URL, getArticleByID, updateArticle };
