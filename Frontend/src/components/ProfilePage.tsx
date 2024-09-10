import Review from "./Review";

export default function ProfilePage(){
    return (
        <>
    <h1>Name</h1>
    <section>
        <h2>Personal details</h2>
        <ul>
            <li>Location</li>
            <li>Description</li>
        </ul>
    </section>
    <section>
        <h2>Reviews</h2>
        <ul>
            <li> <Review/></li>
        </ul>
    </section>
    </>
    )
}