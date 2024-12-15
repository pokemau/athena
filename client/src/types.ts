export type Article = {
	id: number;
	wikiID: number;
	creatorID: number;
	articleTitle: string;
	articleContent: string;
};
export type ArticleUpdate = {
	articleTitle: string;
	articleContent: string;
};
export type Wiki = {
	id: number;
	creatorID: number;
	wikiName: string;
	creatorName: string;
	description: string;
	articles: Article[];
}