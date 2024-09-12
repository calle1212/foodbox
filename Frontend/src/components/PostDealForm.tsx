import { useUser } from "@clerk/clerk-react"
import { useMutation, useQueryClient } from "@tanstack/react-query"
import { useForm, SubmitHandler } from "react-hook-form"


type PostRequest = {
    title: string
    description: string
    payment: string
    location: string
    date: Date
    creatorClerkId: string | undefined
  }
  

export default function PostDealForm() {


    const queryClient = useQueryClient();
    const user = useUser();

    const PostDealQuery  = useMutation({
        mutationFn: () => {
            return fetch(`http://localhost:5063/api/Posts`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: user.user?.id
            })
        },
        onSuccess: () => queryClient.invalidateQueries({ queryKey: ["repoData"] }) 
    });




  const {
    register,
    handleSubmit,
    watch,
    formState: { errors },
  } = useForm<PostRequest>()
  const onSubmit: SubmitHandler<PostRequest> = (data) => {
    data.creatorClerkId = user.user?.id
    console.log(data)
}

  console.log(watch("title")) // watch input value by passing the name of it

  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
    <form className="flex flex-col gap-5 p-3" onSubmit={handleSubmit(onSubmit)}>

      <label > Title: <input {...register("title", { required: true } )} /> </label>
      <label > Description: <input {...register("description", { required: true })} /> </label>
      <label > Payment: <input {...register("payment", { required: true })} type="number"  /> </label>
      <label > Location: <input {...register("location", { required: true })} /> </label>
      <label > Date: <input {...register("date", { required: true })} type="date" /> </label>

      {errors.title && <span>All fields are required</span>}

      <input className="btn btn-primary" type="submit" />
    </form>
  )
}