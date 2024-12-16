export type Article = {
	id: number;
	wikiID: number;
	wikiName: string;
	creatorID: number;
	articleTitle: string;
	articleContent: string;
};
export type ArticleCreate = {
	wikiID: number;
	creatorID: string;
	articleTitle: string;
	articleContent: string;
};
export type ArticleUpdate = {
	articleTitle: string;
	articleContent: string;
};
export type Wiki = {
	id: number;
	creatorID: string;
	wikiName: string;
	creatorName: string;
	description: string;
	articles: Article[];
};
