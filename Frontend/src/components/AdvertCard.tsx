import { Post } from "../types";
import { Link } from '@tanstack/react-router'


export default function AdvertCard(Post: Post) {
    console.log(Post)

    return (
        <>
            <div></div>
            <div className="card bg-base-100 w-64 shadow-xl">
                <figure>
                    <img
                        src={Post.imageUrl || "https://images.pexels.com/photos/1860208/pexels-photo-1860208.jpeg?cs=srgb&dl=cooked-food-1860208.jpg&fm=jpg"}
                        alt="Food image" />
                </figure>
                <div className="card-body">
                    <h2 className="card-title">{Post.title}</h2>
                    <p>{Post.description}</p>
                    <p>{Post.payment} kr</p>
                    <div className="card-actions justify-end">
                        <Link
                            to="/deal"
                            search={{
                                id: {Post}.Post.id,
                            }}
                            className="btn btn-primary">Inpsect job</Link>
                    </div>
                </div>
            </div>
        </>
    )
}