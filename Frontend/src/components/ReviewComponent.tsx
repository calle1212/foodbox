import { Review } from "../types";

export default function ReviewComponent(review : Review){
    return (
        <p>hello from review. {review.rating}</p>
    )
}